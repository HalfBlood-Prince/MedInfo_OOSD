using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Models;
using MedInfo_OOSD.Models.Constants;
using MedInfo_OOSD.Persistence;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace MedInfo_OOSD.Controllers
{
    public class BloodBankController : Controller
    {
        private readonly ApplicationDbContext _context;


        public BloodBankController()
        {
            _context = ApplicationDbContext.Create();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public ActionResult ListOfBanks(bool? isAdded)
        {
            var list = _context.BloodBanks.Where(b => b.IsApproved).ToList();


            var view = User.IsInRole(Roles.SuperAdmin) ? "ListofBanks" : "ListofBanksReadOnly";

            if (isAdded.HasValue && isAdded.Value)
            {
                ViewBag.Massage = "yes";
            }
            else
            {
                ViewBag.Massage = "no";
            }

            return View(view, list);
        }

        // GET: BloodBank/NewBank
        public ActionResult NewBank()
        {
            var viewModel = new BloodBankViewModel();

            return View("BankForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBank(BloodBankViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("BankForm", model);
            }

            var isAdded = true;
            if (model.Id == Guid.Empty)
            {
                var bank = Mapper.Map<BloodBankViewModel, BloodBank>(model);
                if (User.IsInRole(Roles.SuperAdmin) || User.IsInRole(Roles.Moderator))
                {
                    bank.IsApproved = true;
                    isAdded = false;
                }

                bank.ApplicationUserId = User.Identity.GetUserId();

                _context.BloodBanks.Add(bank);
            }
            else
            {
                var bank = _context.BloodBanks.SingleOrDefault(b => b.Id == model.Id);

                Mapper.Map(model, bank);
            }

            _context.SaveChanges();

            return RedirectToAction("ListOfBanks", new {isAdded});
        }

        [Authorize(Roles = Roles.SuperAdmin)]
        public ActionResult EditBank(Guid id)
        {
            var bank = _context.BloodBanks.SingleOrDefault(b => b.Id == id);

            if (bank == null)
                return HttpNotFound();

            var viewModel = Mapper.Map<BloodBank, BloodBankViewModel>(bank);

            return View("BankForm", viewModel);
        }

        public ActionResult Details(Guid id)
        {
            var bank = _context.BloodBanks.SingleOrDefault(b => b.Id == id);

            if (bank == null)
                return HttpNotFound();

            var viewModel = Mapper.Map<BloodBank, BankDetailsViewModel>(bank);

            viewModel.Comments = _context.Comments.Include(c => c.ApplicationUser).Where(c => c.RecordId == id);
            viewModel.ApiKey = ConfigurationManager.AppSettings["apiKey"];

            return View("BankDetails", viewModel);
        }

        public ActionResult AddBankComment(Guid id, BankDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel =
                    Mapper.Map<BloodBank, BankDetailsViewModel>(_context
                        .BloodBanks
                        .SingleOrDefault(b => b.Id == id));

                viewModel.Comments = _context.Comments.Include(c => c.ApplicationUser).Where(c => c.RecordId == id);
                viewModel.ApiKey = ConfigurationManager.AppSettings["apiKey"];

                return View("BankDetails", viewModel);
            }

            if (model.Comment == null)
                return RedirectToAction("Details", new {id});


            model.Comment.RecordId = id;
            model.Comment.ApplicationUserId = User.Identity.GetUserId();
            model.Comment.CommentDateTime = DateTime.Now;


            _context.Comments.Add(Mapper.Map<CommentViewModel, Comment>(model.Comment));
            _context.SaveChanges();

            return RedirectToAction("Details",new {id});
        }
    }
}
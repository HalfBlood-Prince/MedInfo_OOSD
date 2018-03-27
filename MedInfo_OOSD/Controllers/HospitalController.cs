using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Models;
using MedInfo_OOSD.Models.Constants;
using MedInfo_OOSD.Persistence;
using Microsoft.AspNet.Identity;

namespace MedInfo_OOSD.Controllers
{
    public class HospitalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HospitalController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public ActionResult ListOfHospitals(bool? isAdded)
        {
            var hospitals = _context.Hospitals.Where(h => h.IsApproved).ToList();
            var view = User.IsInRole(Roles.SuperAdmin) ? "ListOfHospitals" : "ListOfHospitalsReadonly";

            if (isAdded.HasValue && isAdded.Value)
            {
                ViewBag.Massage = "yes";
            }
            else
            {
                ViewBag.Massage = "no";
            }

            return View(view,hospitals);
        }

        
        public ActionResult NewHospital()
        {
            var viewModel = new NewHospitalViewModel
            {
                Specialities = _context.Specialities.ToList()
            };

            return View("HospitalForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveHospital(NewHospitalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Specialities = _context.Specialities.ToList();

                return View("HospitalForm", model);
            }

            var isAdded = true;
            if (model.Id == Guid.Empty)
            {
                var hospital = Mapper.Map<NewHospitalViewModel, Hospital>(model);

                if (User.IsInRole(Roles.SuperAdmin) || User.IsInRole(Roles.Moderator))
                {
                    hospital.IsApproved = true;
                    isAdded = false;
                }

                hospital.ApplicationUserId = User.Identity.GetUserId();
                _context.Hospitals.Add(hospital);
            }
            else
            {
                var hospital = _context.Hospitals.SingleOrDefault(h => h.Id == model.Id);

                Mapper.Map(model, hospital);
            }

            _context.SaveChanges();
            return RedirectToAction("ListOfHospitals", "Hospital", new {isAdded});
        }

        public ActionResult EditHospital(Guid id)
        {
            var hospital = _context.Hospitals.SingleOrDefault(h => h.Id == id);

            if (hospital == null)
                return HttpNotFound();

            var viewModel = Mapper.Map<Hospital, NewHospitalViewModel>(hospital);
            viewModel.Specialities = _context.Specialities.ToList();

            return View("HospitalForm",viewModel);
        }

        [AllowAnonymous]
        public ActionResult HospitalDetails(Guid id)
        {
            var hospital = _context.Hospitals.Include(h => h.Speciality).SingleOrDefault(h => h.Id == id);

            if (hospital == null)
                return HttpNotFound();

            var viewModel = Mapper.Map<Hospital, HospitalDetailsViewModel>(hospital);
            viewModel.Comments = _context.Comments.Include(c => c.ApplicationUser).Where(c => c.RecordId == id).ToList();
            viewModel.ApiKey = ConfigurationManager.AppSettings["apiKey"];

            return View("HospitalDetails", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHospitalComment(Guid id, HospitalDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var hospital = _context.Hospitals.Include(d => d.Speciality).SingleOrDefault(c => c.Id == id);
                var viewModel = Mapper.Map<Hospital, HospitalDetailsViewModel>(hospital);
                viewModel.Comments = _context.Comments.Include(c => c.ApplicationUser).Where(c => c.RecordId == id).ToList();
                viewModel.ApiKey = ConfigurationManager.AppSettings["apiKey"];

                return View("HospitalDetails", viewModel);
            }

            if (model.Comment == null)
                return RedirectToAction("HospitalDetails", new {id});

            model.Comment.ApplicationUserId = User.Identity.GetUserId();
            model.Comment.RecordId = id;
            model.Comment.CommentDateTime = DateTime.Now;

            _context.Comments.Add(Mapper.Map<CommentViewModel, Comment>(model.Comment));
            _context.SaveChanges();
            
            return RedirectToAction("HospitalDetails", new {id});
        }
    }
}
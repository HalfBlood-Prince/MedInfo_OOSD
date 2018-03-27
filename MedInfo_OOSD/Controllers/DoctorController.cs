using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Models;
using MedInfo_OOSD.Persistence;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using MedInfo_OOSD.Models.Constants;

namespace MedInfo_OOSD.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }


        //
        /// <summary>
        ///     This action serves list of doctors.
        ///     It serves two differnt view based on
        ///     users role.  
        /// </summary>
        /// <param name="isAdded">it takes a nullable parameter. it dtermines any new recored is added or not</param>
        /// <returns>it returns two views in form of viewresult</returns>
        [AllowAnonymous]
        public ActionResult ListOfDoctors(bool? isAdded)
        {
            var list = _context.Doctors.Include(d => d.Speciality)
                .Where(d => d.IsApproved)
                .ToList();

            var view = User.IsInRole(Roles.SuperAdmin) ? "ListofDoctors" : "ListofDoctorsReadOnly";

            if (isAdded.HasValue && isAdded.Value)
            {
                ViewBag.Massage = "yes";
            }
            else
            {
                ViewBag.Massage = "no";
            }

            return View(view,list);
        }


        //
        /// <summary>
        ///     This is a action which serves new doctor form.
        /// </summary>
        /// <returns> return a view in form of view result</returns>
        public ActionResult NewDoctor()
        {
            var viewModel = new NewDoctorViewModel
            {
                Specialities = _context.Specialities
            };

            return View("DoctorForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDoctor(NewDoctorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Specialities = _context.Specialities.ToList();

                return View("DoctorForm", model);
            }

            var isAdded = true;
            if (model.Id == Guid.Empty)
            {
                var doctor = Mapper.Map<NewDoctorViewModel, Doctor>(model);

                if (User.IsInRole(Roles.SuperAdmin) || User.IsInRole(Roles.Moderator))
                {
                    doctor.IsApproved = true;
                    isAdded = false;
                }


                doctor.ApplicationUserId = User.Identity.GetUserId();
                _context.Doctors.Add(doctor);
            }
            else
            {
                var doctor = _context.Doctors.SingleOrDefault(d => d.Id == model.Id);

                Mapper.Map(model, doctor);
            }


            _context.SaveChanges();
            return RedirectToAction("ListOfDoctors", "Doctor", new {isAdded});
        }

        [Authorize(Roles = Roles.SuperAdmin)]
        public ActionResult EditDoctor(Guid id)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == id);

            var viewModel = new NewDoctorViewModel()
            {
                Specialities = _context.Specialities.ToList()
            };

            Mapper.Map(doctor, viewModel);
            return View("DoctorForm",viewModel);
        }

        [AllowAnonymous]
        public ActionResult DoctorDetails(Guid id)
        {
            var doctor = _context.Doctors.Include(d => d.Speciality).SingleOrDefault(d => d.Id == id);

            var viewModel = Mapper.Map<Doctor, DoctorDetailsViewModel>(doctor);
            viewModel.Comments = _context.Comments.Include(c => c.ApplicationUser).Where(c => c.RecordId == id).ToList();
            viewModel.ApiKey = ConfigurationManager.AppSettings["apiKey"];

            return View("DoctorDetails", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDoctorComment(Guid id, DoctorDetailsViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var doc = _context.Doctors.Include(d => d.Speciality).SingleOrDefault(d => d.Id == id);
                var viewModel = Mapper.Map<Doctor, DoctorDetailsViewModel>(doc);
                viewModel.Comments = _context.Comments.Include(c => c.ApplicationUser).Where(c => c.RecordId == id);
                viewModel.ApiKey = ConfigurationManager.AppSettings["apiKey"];

                return View("DoctorDetails", viewModel);
            }

            if (model.Comment == null)
                return RedirectToAction("DoctorDetails", new { id });


            model.Comment.RecordId = id;
            model.Comment.ApplicationUserId = User.Identity.GetUserId();
            model.Comment.CommentDateTime = DateTime.Now;

            _context.Comments.Add(Mapper.Map<CommentViewModel, Comment>(model.Comment));
            _context.SaveChanges();

            return RedirectToAction("DoctorDetails", new {id});
        }
    }


}
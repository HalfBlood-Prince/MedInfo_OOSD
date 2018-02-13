using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Models;
using MedInfo_OOSD.Persistence;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

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

        [AllowAnonymous]
        public ActionResult ListOfDoctors()
        {
            var list = _context.Doctors.Include(d => d.Speciality).ToList();

            var view = User.IsInRole(Roles.SuperAdmin) ? "ListofDoctors" : "ListofDoctorsReadOnly";

            return View(view,list);
        }

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

            if (model.Id == Guid.Empty)
            {
                var doctor = Mapper.Map<NewDoctorViewModel, Doctor>(model);
                doctor.ApplicationUserId = User.Identity.GetUserId();
                _context.Doctors.Add(doctor);

            }
            else
            {
                var doctor = _context.Doctors.SingleOrDefault(d => d.Id == model.Id);

                Mapper.Map(model, doctor);
            }


            _context.SaveChanges();
            return RedirectToAction("ListOfDoctors", "Doctor");
        }


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

            return View("DoctorDetails", Mapper.Map<Doctor,NewDoctorViewModel>(doctor));
        }

    }


}
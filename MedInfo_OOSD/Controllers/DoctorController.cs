﻿using System;
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
        public ActionResult ListOfDoctors(bool? isAdded)
        {
            var list = _context.Doctors.Include(d => d.Speciality).Where(d => d.IsApproved).ToList();

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

            var isAdded = false;
            if (model.Id == Guid.Empty)
            {
                var doctor = Mapper.Map<NewDoctorViewModel, Doctor>(model);

                if (User.IsInRole(Roles.SuperAdmin))
                    doctor.IsApproved = true;


                doctor.ApplicationUserId = User.Identity.GetUserId();
                _context.Doctors.Add(doctor);
                isAdded = true;
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
            viewModel.Name = "Tanim";
            return View("DoctorForm",viewModel);
        }

        [AllowAnonymous]
        public ActionResult DoctorDetails(Guid id)
        {
            var doctor = _context.Doctors.Include(d => d.Speciality).SingleOrDefault(d => d.Id == id);

            var viewModel = Mapper.Map<Doctor, DoctorDetailsViewModel>(doctor);
            viewModel.Comments = _context.Comments.Include(c => c.ApplicationUser).Where(c => c.RecordId == id).ToList();


            return View("DoctorDetails", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDoctorComment(Guid id, DoctorDetailsViewModel model)
        {
            var doctor = _context.Doctors.Include(d => d.Speciality).SingleOrDefault(d => d.Id == id);

            Mapper.Map(doctor, model);

            if (!ModelState.IsValid)
            {
                return View("DoctorDetails", model);
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
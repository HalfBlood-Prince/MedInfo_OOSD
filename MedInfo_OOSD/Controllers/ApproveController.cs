﻿using System.Linq;
using System.Web.Mvc;
using MedInfo_OOSD.Models;
using MedInfo_OOSD.Models.Constants;
using MedInfo_OOSD.Models.Enum;
using MedInfo_OOSD.Persistence;

namespace MedInfo_OOSD.Controllers
{
    public class ApproveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApproveController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        //
        // GET: /Approve/Index
        // returns list of unappprovd doctors
        [Authorize(Roles = Roles.SuperAdmin_Moderator)]
        public ActionResult Index()
        {
            var viewModel = new ApproveListViewModel
            {
                Entities = _context.Doctors.Where(d => !d.IsApproved).ToList(),
                Action = Actions.DoctorDetails,
                Controller = Models.Constants.Controllers.Doctor,
                Api = Apies.Doctors
            };

            return View("ApproveList", viewModel);
        }


        //
        // POST: /Approve/ApproveList
        // returns list of unapproved records 
        // based on an id
        [HttpPost]
        public ActionResult ApproveList(int id)
        {
            if (id == 0)
                return HttpNotFound();

            var entity = (EntityType)id;
            ApproveListViewModel viewModel;

            switch (entity)
            {
                case EntityType.Doctors:
                     viewModel = new ApproveListViewModel
                    {
                        Entities = _context.Doctors.Where(d => !d.IsApproved),
                        Action = Actions.DoctorDetails,
                        Controller = Models.Constants.Controllers.Doctor,
                        Api = Apies.Doctors
                    };
                    break;
                case EntityType.Hospitals:
                     viewModel = new ApproveListViewModel
                    {
                        Entities = _context.Hospitals.Where(d => !d.IsApproved),
                        Action = Actions.HospitalDetails,
                        Controller = Models.Constants.Controllers.Hospital,
                        Api = Apies.Hospitals
                    };
                    break;
                case EntityType.Banks:
                    viewModel = new ApproveListViewModel
                    {
                        Entities = _context.BloodBanks.Where(d => !d.IsApproved),
                        Action = Actions.BankDetails,
                        Controller = Models.Constants.Controllers.BloodBank,
                        Api = Apies.Banks
                    };
                    break;
                    default:
                        viewModel = new ApproveListViewModel
                        {
                            Entities = _context.Doctors.Where(d => !d.IsApproved),
                            Action = Actions.DoctorDetails,
                            Controller = Models.Constants.Controllers.Doctor,
                            Api = Apies.Doctors
                        };
                        break;
            }


            return View("ApproveList",viewModel);
        }
   
    }
}
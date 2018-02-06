using System.Web.Mvc;
using MedInfo_OOSD.Models;
using MedInfo_OOSD.Persistence;

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

        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewDoctor()
        {
            var viewModel = new NewDoctorViewModel
            {
                Specialities = _context.Specialities
            };


            return View("DoctorForm", viewModel);
        }
    }
}
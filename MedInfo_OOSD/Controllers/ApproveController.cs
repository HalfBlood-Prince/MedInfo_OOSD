using System.Linq;
using System.Web.Mvc;
using MedInfo_OOSD.Models;
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

        // GET: Approve
        [Authorize(Roles = Roles.SuperAdmin)]
        public ActionResult Index()
        {
            var doctors = _context.Doctors.Where(d => !d.IsApproved).ToList();

            ViewBag.Action = "DoctorDetails";
            ViewBag.Controller = "Doctor";
            ViewBag.Api = "doctors";

            return View("ApproveList",doctors);
        }
    }
}
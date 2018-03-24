using System.Web.Mvc;

namespace MedInfo_OOSD.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View("Shout");
        }

        public ActionResult Support()
        {
            return View();
        }
    }
}
using WebApp.Filters;
using System.Security.Claims;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class AppController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AntiForgeryHeader]
        public ActionResult Token()
        {
            var identity = User.Identity as ClaimsIdentity;
            return Json(new { id_token = identity.FindFirst("id_token").Value }, JsonRequestBehavior.AllowGet);
        }
    }
}
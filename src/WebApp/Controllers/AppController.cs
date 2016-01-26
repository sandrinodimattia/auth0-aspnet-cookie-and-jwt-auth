using WebApp.Filters;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Configuration;

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

            if (bool.Parse(WebConfigurationManager.AppSettings["EnableRefreshTokens"]))
                return Json(new { id_token = identity.FindFirst("id_token").Value, refresh_token = identity.FindFirst("refresh_token").Value }, JsonRequestBehavior.AllowGet);
            return Json(new { id_token = identity.FindFirst("id_token").Value }, JsonRequestBehavior.AllowGet);
        }
    }
}
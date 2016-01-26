using System.Web.Configuration;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (bool.Parse(WebConfigurationManager.AppSettings["EnableRefreshTokens"]))
            {
                ViewBag.Scope = "openid name email offline_access";
            }
            else
            {
                ViewBag.Scope = "openid name email";
            }

            return View();
        }
    }
}
using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WebApp.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AntiForgeryHeaderAttribute : FilterAttribute, IAuthorizationFilter
    {
        private void ValidateRequestHeader(HttpRequestBase request)
        {
            var cookieValue = String.Empty;
            var cookie = request.Cookies[AntiForgeryConfig.CookieName];
            if (cookie != null)
                cookieValue = cookie.Value;
            var headerValue = request.Headers["RequestVerificationToken"];

            AntiForgery.Validate(cookieValue, headerValue);
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {

            try
            {
                ValidateRequestHeader(filterContext.HttpContext.Request);
            }
            catch (HttpAntiForgeryException)
            {
                throw new HttpAntiForgeryException("CSRF validation failed.");
            }
        }
    }
}
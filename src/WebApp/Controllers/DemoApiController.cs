using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using System.Linq;

namespace WebApp.Controllers
{
    [Authorize]
    public class DemoApiController : ApiController
    {
        public Dictionary<string, string> Get()
        {
            var identity = User.Identity as ClaimsIdentity;
            return identity.Claims.ToDictionary(c => c.Type, c => c.Value);
        }
    }
}

using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace OwinTockenBasedAuthenticationSample.Controllers
{
    public class BaseWebApiController : ApiController
    {
        public string UserName { get; set; }
        public long UserId { get; set; }

        public BaseWebApiController()
        {
            if (ClaimsPrincipal.Current != null && ClaimsPrincipal.Current.Identity != null && ClaimsPrincipal.Current.Identity.IsAuthenticated)
            {
                //Add the values to attributes of basewebapi which will be available in api (user info)
                ClaimsPrincipal claimsPrincipal = RequestContext.Principal as ClaimsPrincipal;
                UserName = claimsPrincipal.Claims.Where(c => c.Type == "UserName").Single().Value;
            }
        }
    }
}

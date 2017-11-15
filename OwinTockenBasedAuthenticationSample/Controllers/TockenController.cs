using System.Web.Http;

namespace OwinTockenBasedAuthenticationSample.Controllers
{
    public class TockenController : BaseWebApiController
    {
        //https://blogs.perficient.com/delivery/blog/2017/06/11/token-based-authentication-in-web-api-2-via-owin/
        [Authorize]
        public IHttpActionResult Authorize()
        {
           return Ok(string.Format("Name: {0}",UserName));
        }
    }
}

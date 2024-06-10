using Abo.Demo1.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace Abo.Demo1.Web.Modules
{
    public class Tools : Controller
    {
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;

        public Tools(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("ProxyServiceJs.js")]
        public IActionResult ProxyServiceJs()
        {

            HttpContext.Response.ContentType = "application/javascript";
            var proxy = new ApiProxy(Configuration);
            var js = proxy.GetApiProxyJs();
         return   Content(js, "application/javascript");
            
        }
    }
}

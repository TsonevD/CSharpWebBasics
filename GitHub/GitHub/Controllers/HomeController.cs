using MyWebServer.Controllers;
using MyWebServer.Http;

namespace GitHub.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}

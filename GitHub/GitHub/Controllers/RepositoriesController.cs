using MyWebServer.Controllers;
using MyWebServer.Http;

namespace GitHub.Controllers
{
    public class RepositoriesController : Controller
    {

        public HttpResponse All()
        {


            return View();
        }
        public HttpResponse Create() => View();
    }
}

using MyWebServer.Controllers;
using MyWebServer.Http;

namespace GitHub.Controllers
{
    public class CommitsController : Controller
    {




        public HttpResponse All() => View();
        public HttpResponse Create() => View();
    }
}

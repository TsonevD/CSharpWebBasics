using MyWebServer.Controllers;
using MyWebServer.Http;

namespace GitHub.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Repositories/All");
            }
            return this.View();
        }
    }
}

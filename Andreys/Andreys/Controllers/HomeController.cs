using System.Linq;
using Andreys.Data;
using Andreys.Models.Home;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Andreys.Controllers
{
    public class HomeController : Controller
    {
        private readonly AndreysDbContext data;

        public HomeController(AndreysDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse Home()
        {
            var products = this.data.Products
                .Select(x => new HomeViewModel()
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Price = x.Price,
            }).ToList();

            return View(products);
        }


        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Home();
            }
            return this.View();
        }
    }
}

using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Cars;
using CarShop.Services.Contacts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IUsersService usersService;
        private readonly IValidator validator;

        public CarsController(ApplicationDbContext data, IUsersService usersService, IValidator validator)
        {
            this.data = data;
            this.usersService = usersService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (this.usersService.IsMechanic(this.User.Id))
            {
                return Error("Mechanics cannot add cars.");
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(CarsAddInputModel model)
        {
            if (this.usersService.IsMechanic(this.User.Id))
            {
                return Unauthorized();
            }
            var errors = this.validator.ValidateNewCar(model);
            if (errors.Any())
            {
                return Error(errors);
            }
            var car = new Car()
            {
                Model = model.Model,
                PlateNumber = model.PlateNumber,
                Year = model.Year,
                PictureUrl = model.Image,
                OwnerId = this.User.Id,
            };
            this.data.Cars.Add(car);
            this.data.SaveChanges();

            return Redirect("/Cars/All");
        }
        [Authorize]
        public HttpResponse All()
        {
            var cars = this.data
                .Cars
                .AsQueryable();

            if (this.usersService.IsMechanic(this.User.Id))
            {
                cars = cars.Where(x => x.Issues.Any(x => x!.IsFixed));
            }
            else
            {
                cars = cars.Where(x => x.OwnerId == this.User.Id);
            }
            var allCars = cars
                .Select(x => new CarsAllViewModel()
            {
                Id = x.Id,
                ImageUrl = x.PictureUrl,
                PlateNumber = x.PlateNumber,
                Model = x.Model,
                Year = x.Year,
                FixedIssues = x.Issues.Count(i=>i.IsFixed),
                RemainingIssues = x.Issues.Count(i =>!i.IsFixed)
            }).ToList();

            return View(allCars);
        }
    }
}

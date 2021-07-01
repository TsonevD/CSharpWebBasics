using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Issues;
using CarShop.Services.Contacts;
using Microsoft.EntityFrameworkCore.Migrations;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public IssuesController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }
        [Authorize]
        public HttpResponse Add(string carId)
        {
            var car = this.data.Cars.Where(x => x.Id == carId)
                .Select(x=> new CarAddViewModel()
                {
                    Id = x.Id,
                }).FirstOrDefault();

            return View(car);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(IssueAddInputModel model)
        {
            var errors = this.validator.ValidateIssue(model);
            if (errors.Any())
            {
                return Error(errors);
            }
            var issue = new Issue()
            {
                CarId = model.CarId,
                Description = model.Description,
            };
            this.data.Issues.Add(issue);
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {

            var var = this.data.Cars.Where(x => x.Id == carId)
                .Select(x => new CarIssueViewModel()
                {
                    Id = x.Id,
                    Model = x.Model,
                    Year = x.Year,
                    UserIsMechanic = x.Owner.IsMechanic,
                    Issues = x.Issues.Select(i => new IssueListingViewModel()
                    {
                        Id = i.Id,
                        IsFixed = i.IsFixed ? "Yes" : "Not yet",
                        Description = i.Description,
                    }).ToList()
                }).FirstOrDefault();

            return View(var);
        }
        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
          

            return View();
        }
        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
        

            return View();
        }

    }


}

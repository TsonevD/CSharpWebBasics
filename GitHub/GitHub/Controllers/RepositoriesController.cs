using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using GitHub.Data;
using GitHub.Data.Models;
using GitHub.Models.Repositories;
using GitHub.Services.Contacts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace GitHub.Controllers
{
    using static DataConstants;
    public class RepositoriesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public RepositoriesController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse Create() => View();

        public HttpResponse All()
        {
            var allRepositories = this.data.Repositories
                .Where(x => x.IsPublic)
                .Select(x => new AllRepositoriesViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedOn = x.CreatedOn,
                    Owner = x.Owner.Username,
                    CommitsCount = x.Commits.Count(c=>c.RepositoryId==x.Id)
                })
                .ToList();

            return View(allRepositories);
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel model)
        {
            var errors = ValidateNewRepository(model);
            if (errors.Any())
            {
                return Error(errors);
            }

            var repository = new Repository()
            {
                Name = model.Name,
                OwnerId = this.User.Id,
                IsPublic = model.RepositoryType == PublicRepositoryType,
            };
            this.data.Repositories.Add(repository);
            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        private ICollection<string> ValidateNewRepository(CreateRepositoryInputModel model)
        {
            var errors = this.validator.ValidateRepository(model);
            if (this.data.Repositories.Any(x => x.Name == model.Name))
            {
               errors.Add($"The repository {model.Name} is already in the system.Please choose different name.");
            }
            return errors;
        }
    }
}

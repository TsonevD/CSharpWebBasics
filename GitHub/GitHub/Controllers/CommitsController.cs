using System.Linq;
using GitHub.Data;
using GitHub.Data.Models;
using GitHub.Models.Commits;
using GitHub.Services.Contacts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace GitHub.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public CommitsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.data.Commits
                .Where(x => x.CreatorId == this.User.Id)
                .Select(x => new AllCommitsViewModel()
                {
                    Description = x.Description,
                    RepositoryName = x.Repository.Name,
                    CreatedOn = x.CreatedOn.ToLocalTime().ToString(),
                    Id = x.Id,
                }).ToList();

            return View(commits);
        }
        [Authorize]
        public HttpResponse Create(string id)
        {
            var repository = this.data.Repositories
                .Where(x => x.Id == id)
                .Select(x => new CreateCommitViewModel()
                {
                    Name = x.Name,
                    Id = id
                }).FirstOrDefault();

            if (repository == null)
            {
                return Error("Invalid Repository.");
            }

            return View(repository);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateCommitInputModel model)
        {
            var errors = this.validator.ValidateCommit(model);
            if (errors.Any())
            {
                return Error(errors);
            }

            var repo = this.data.Repositories.Find(model.Id);

            var commit = new Commit()
            {
                Description = model.Description,
                CreatorId = this.User.Id,
                RepositoryId = model.Id
            };

            this.data.Commits.Add(commit);
            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.data.Commits
                .FirstOrDefault(x => x.Id == id && x.CreatorId == this.User.Id);

            if (commit == null)
            {
                return Error("You don`t have access to this commit");
            }

            this.data.Commits.Remove(commit);
            this.data.SaveChanges();
            
            return Redirect("/Commits/All");
            
        }
    }
}

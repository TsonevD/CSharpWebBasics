using System.Collections.Generic;
using System.Linq;
using GitHub.Models.Users;
using GitHub.Services;
using GitHub.Services.Contacts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace GitHub.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IUsersService usersService;

        public UsersController(IValidator validator, IUsersService usersService)
        {
            this.validator = validator;
            this.usersService = usersService;
        }
		public HttpResponse Login() => View();
        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(UserRegistrationViewModel model)
        {
            var errors = ValidateRegistrationUser(model);
            if (errors.Any())
            {
                return Error(errors);
            }

            usersService.CreateUser(model.Username, model.Email, model.Password);

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public HttpResponse Login(UserLoginViewModel model)
        {
            var error = this.ValidateLoginUser(model);
            if (error.Any())
            {
                return Error(error);
            }

            this.SignIn(usersService.GetUserId(model.Username, model.Password));

            return Redirect("/Repositories/All");
        }
 
        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }

        private ICollection<string> ValidateRegistrationUser(UserRegistrationViewModel model)
        {
            var errors = this.validator.ValidateRegistration(model);

            if (usersService.IsUsernameAvailable(model.Username))
            {
                errors.Add($"Username {model.Username} already exist in the system.");
            }
            if (usersService.IsEmailAvailable(model.Email))
            {
                errors.Add("The email is already register in the system.");
            }
            return errors;
        }
        private ICollection<string> ValidateLoginUser(UserLoginViewModel model)
        {
            var errors = this.validator.ValidateLogin(model);
            var userId = usersService.GetUserId(model.Username, model.Password);

            if (userId == null)
            {
                errors.Add("Username or password are invalid !");
            }

            return errors;
        }
    }
}

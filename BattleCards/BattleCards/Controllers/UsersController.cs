using System.Linq;
using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.Models;
using BattleCards.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace BattleCards.Controllers
{
    using static DataConstants;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;
        private readonly PasswordHasher passwordHasher;

        public UsersController(IValidator validator, ApplicationDbContext data, PasswordHasher passwordHasher)
        {
            this.validator = validator;
            this.data = data;
            this.passwordHasher = passwordHasher;
        }
		public HttpResponse Login() => View();

        public HttpResponse Register() => View();

		[HttpPost]
        public HttpResponse Login(UserLoginViewModel model)
        {
			var errors = this.validator.ValidateLogin(model);
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data.Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();
            if (userId == null)
            {
                errors.Add("Username or password are invalid !");
            }
            if (errors.Any())
            {
                return Error(errors);
            }
            this.SignIn(userId);

            return Redirect("/");
        }
        [HttpPost]
        public HttpResponse Register(UserRegistrationViewModel model)
        {
            var errors = this.validator.ValidateRegistration(model);
            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                errors.Add($"Username {model.Username} already exist in the system.");
            }
            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                errors.Add("The email is already register in the system.");
            }
            if (errors.Any())
            {
                return Error(errors);
            }

            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHasher.HashPassword(model.Password),
            
            };
            this.data.Users.Add(user);

            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }
        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}

using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services.Contacts;

namespace CarShop.Services
{
    using static DataConstants;
    public class UserService : IUsersService
    {
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;
        public UserService(ApplicationDbContext data, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public string CreateUser(string username, string email, string password, string userType)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
                IsMechanic = userType == UserTypeMechanic,
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();

            return user.Id;
        }

        public string GetUserId(string username, string password)
            => this.data.Users
                .Where(u => u.Username == username && u.Password == this.HashPassword(password))
                .Select(u => u.Id)
                .FirstOrDefault();


        public bool IsMechanic(string userId)
            => this.data.Users.Any(x => x.Id==userId && x.IsMechanic);

        public bool IsEmailAvailable(string email)
            => this.data.Users.Any(u => u.Email == email);

        public bool IsUsernameAvailable(string username)
            => this.data.Users.Any(u => u.Username == username);

        public string HashPassword(string password)
            => passwordHasher.HashPassword(password);
    }
}

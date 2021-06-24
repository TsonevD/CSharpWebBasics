using System.Linq;
using Andreys.Data;
using Andreys.Data.Models;
using Andreys.Services.Contacts;

namespace Andreys.Services
{
    public class UserService : IUserService
    {
        private readonly AndreysDbContext data;
        private readonly IPasswordHasher passwordHasher;
        public UserService(AndreysDbContext data, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
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
            

        public bool IsEmailAvailable(string email)
            => this.data.Users.Any(u => u.Email == email);

        public bool IsUsernameAvailable(string username)
            => this.data.Users.Any(u => u.Username == username);

        public string HashPassword(string password)
            => passwordHasher.HashPassword(password);
    }
}

using System.Linq;
using GitHub.Data;
using GitHub.Data.Models;
using GitHub.Services.Contacts;

namespace GitHub.Services
{
    public class UserService : IUsersService
    {
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;
        public UserService(ApplicationDbContext data, IPasswordHasher passwordHasher)
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

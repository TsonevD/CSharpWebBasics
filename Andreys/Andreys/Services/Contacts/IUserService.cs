namespace Andreys.Services.Contacts
{
    public interface IUserService
    {
        string CreateUser(string username, string email, string password);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        string HashPassword(string password);

    }
}

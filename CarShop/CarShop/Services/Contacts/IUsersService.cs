namespace CarShop.Services.Contacts
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password,string UserType);

        bool IsEmailAvailable(string email);
        bool IsMechanic(string userId);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        string HashPassword(string password);

    }
}

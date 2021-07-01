namespace CarShop.Services.Contacts
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
namespace SharedTrip.Services.Contacts
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
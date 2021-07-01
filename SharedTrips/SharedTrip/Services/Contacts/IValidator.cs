using System.Collections.Generic;
using SharedTrip.ViewModels.Trips;
using SharedTrip.ViewModels.Users;

namespace SharedTrip.Services.Contacts
{
    public interface IValidator
    {
        ICollection<string> ValidateRegistration(UserRegistrationViewModel model);
        ICollection<string> ValidateLogin(UserLoginViewModel model);
        ICollection<string> ValidateTrip(AddTripInputModel model);
    }
}

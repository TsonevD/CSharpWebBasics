using System.Collections.Generic;
using GitHub.Models.Users;

namespace GitHub.Services.Contacts
{
    public interface IValidator
    {
        ICollection<string> ValidateRegistration(UserRegistrationViewModel model);

        ICollection<string> ValidateLogin(UserLoginViewModel model);
    }
}

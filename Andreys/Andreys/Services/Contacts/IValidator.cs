using System.Collections.Generic;
using Andreys.Models.Products;
using Andreys.Models.Users;

namespace Andreys.Services.Contacts
{
    public interface IValidator
    {
        ICollection<string> ValidateRegistration(UserRegistrationViewModel model);

        ICollection<string> ValidateLogin(UserLoginViewModel model);

        ICollection<string> ValidateProduct(ProductAddInputModel model);
    }
}

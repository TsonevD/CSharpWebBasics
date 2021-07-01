using System.Collections.Generic;
using CarShop.Models.Cars;
using CarShop.Models.Issues;
using CarShop.Models.Users;

namespace CarShop.Services.Contacts
{
    public interface IValidator
    {
        ICollection<string> ValidateRegistration(UserRegistrationViewModel model);
        ICollection<string> ValidateLogin(UserLoginViewModel model);
        ICollection<string> ValidateNewCar(CarsAddInputModel model);
        ICollection<string> ValidateIssue(IssueAddInputModel model);
    }
}

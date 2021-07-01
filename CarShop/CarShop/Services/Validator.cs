using System.Collections.Generic;
using System.Text.RegularExpressions;
using CarShop.Data;
using CarShop.Models.Cars;
using CarShop.Models.Issues;
using CarShop.Models.Users;
using CarShop.Services.Contacts;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Services
{
    using static DataConstants;
    public class Validator : IValidator
    {

        public ICollection<string> ValidateRegistration(UserRegistrationViewModel model)
        {
            var errors = new List<string>();
            if (model.Username.Length < UsernameMinLength || model.Username.Length > UserValidationMaxLength)
            {
                errors.Add($"Username `{model.Username}` must be between {UsernameMinLength} and {UserValidationMaxLength} symbols.");
            }
            if (model.Password.Length < UserPasswordMinLength || model.Password.Length > UserValidationMaxLength)
            {
                errors.Add($"Password must be between {UserPasswordMinLength} and {UserValidationMaxLength} symbols.");
            }
            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add("Invalid email address.");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Both password must identical.");
            }
            if (model.UserType != UserTypeMechanic && model.UserType != UserTypeClient)
            {
                errors.Add($"User{model.Username} should be either {UserTypeClient} or {UserTypeMechanic}.");
            }
            return errors;
        }

        public ICollection<string> ValidateLogin(UserLoginViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > UserValidationMaxLength)
            {
                errors.Add($"Username `{model.Username}` must be between {UsernameMinLength} and {UserValidationMaxLength} symbols.");
            }
            if (model.Password.Length < UserPasswordMinLength || model.Password.Length > UserValidationMaxLength)
            {
                errors.Add($"Password must be between {UserPasswordMinLength} and {UserValidationMaxLength} symbols.");
            }
            return errors;
        }

        public ICollection<string> ValidateNewCar(CarsAddInputModel model)
        {
            var errors = new List<string>();
            if (model.Model.Length < CarModelDefaultMinLength || model.Model.Length > CarModelDefaultMaxLength)
            {
                errors.Add($"Car `{model.Model}` must be between {CarModelDefaultMinLength} and {CarModelDefaultMaxLength} symbols.");
            }
            if (model.PlateNumber.Length > CarPlateNumberMaxlength && Regex.IsMatch(model.PlateNumber, CarPlateNumberRegularExpression))
            {
                errors.Add($"Car plate {model.PlateNumber} cannot be more than {CarPlateNumberMaxlength} symbols and it must be in a format 'AA1234AA'.");
            }
            return errors;
        }

        public ICollection<string> ValidateIssue(IssueAddInputModel model)
        {
            var errors = new List<string>();
            if (model.Description.Length < IssueDescriptionMinLength)
            {
                errors.Add($"Description cannot be less than {IssueDescriptionMinLength}.");
            }
            return errors;
        }
    }
}

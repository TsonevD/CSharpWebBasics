using System.Collections.Generic;
using System.Text.RegularExpressions;
using Andreys.Data;
using Andreys.Models.Products;
using Andreys.Models.Users;
using Andreys.Services.Contacts;

namespace Andreys.Services
{
    using static DataConstants;
    public class Validator : IValidator
    {
        public ICollection<string> ValidateRegistration(UserRegistrationViewModel model)
        {
            var errors = new List<string>();
            if (model.Username.Length < UserMinLength || model.Username.Length > UserMaxLength)
            {
                errors.Add($"Username `{model.Username}` must be between {UserMinLength} and {UserMaxLength} symbols.");
            }
            if (model.Password.Length < PasswordMinLength || model.Password.Length > PasswordMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {PasswordMaxLength} symbols.");
            }
            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add("Invalid email address.");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Both password must identical.");
            }

            return errors;
        }

        public ICollection<string> ValidateLogin(UserLoginViewModel model)
        {
            var errors = new List<string>();
            if (model.Username.Length < UserMinLength || model.Username.Length > UserMaxLength)
            {
                errors.Add($"Username {model.Username} must be between {UserMinLength} and {UserMaxLength} symbols.");
            }
            if (model.Password.Length < PasswordMinLength || model.Password.Length > PasswordMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {PasswordMaxLength} symbols.");
            }
            return errors;
        }

        public ICollection<string> ValidateProduct(ProductAddInputModel model)
        {
            var errors = new List<string>();
            if (model.Name.Length < NameMinLength || model.Name.Length > NameMaxLength)
            {
                errors.Add($"Username `{model.Name}` must be between {NameMinLength} and {NameMaxLength} symbols.");
            }
            if (model.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description cannot be more than {DescriptionMaxLength}  symbols.");
            }
            return errors;
        }
    }
}

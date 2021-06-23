using BattleCards.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BattleCards.Models;
using BattleCards.Models.Cards;

namespace BattleCards.Services
{
    using static DataConstants;
    public class Validator : IValidator
    {
        public ICollection<string> ValidateRegistration(UserRegistrationViewModel model)
        {
            var errors = new List<string>();
            if (model.Username.Length < UserMinLength || model.Username.Length > UserDefaultMaxLength)
            {
                errors.Add($"Username {model.Username} must be between {UserMinLength} and {UserDefaultMaxLength} symbols.");
            }
            if (model.Password.Length < PasswordMinLength || model.Password.Length > UserDefaultMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {UserDefaultMaxLength} symbols.");
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
            if (model.Username.Length < UserMinLength || model.Username.Length > UserDefaultMaxLength)
            {
                errors.Add($"Username {model.Username} must be between {UserMinLength} and {UserDefaultMaxLength} symbols.");
            }
            if (model.Password.Length < PasswordMinLength || model.Password.Length > UserDefaultMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {UserDefaultMaxLength} symbols.");
            }
            return errors;
        }

        public ICollection<string> ValidateNewCard(AddNewCadInputModel model)
        {
            var errors = new List<string>();
            if (model.Name.Length < CardNameMinLength || model.Name.Length > CardNameMaxLength)
            {
                errors.Add($"Name {model.Name} must be between {CardNameMinLength} and {CardNameMaxLength} symbols.");
            }
            if (model.Attack < CardHealthAndAttackMinLength)
            {
                errors.Add($"Attack cannot be below {CardHealthAndAttackMinLength}.");
            }
            if (model.Health < CardHealthAndAttackMinLength)
            {
                errors.Add($"Health cannot be below {CardHealthAndAttackMinLength}.");
            }
            if (model.Description.Length > CardDescriptionMaxLength)
            {
                errors.Add($"Description cannot be more than {CardDescriptionMaxLength} symbols.");
            }
            return errors;
        }
    }
}

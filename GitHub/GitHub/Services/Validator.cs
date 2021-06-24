using System.Collections.Generic;
using System.Text.RegularExpressions;
using GitHub.Data;
using GitHub.Models.Commits;
using GitHub.Models.Repositories;
using GitHub.Models.Users;
using GitHub.Services.Contacts;

namespace GitHub.Services
{
    using static DataConstants;
    public class Validator : IValidator
    {
        public ICollection<string> ValidateRegistration(UserRegistrationViewModel model)
        {
            var errors = new List<string>();
            if (model.Username.Length < UserMinLength || model.Username.Length > UserDefaultMaxLength)
            {
                errors.Add($"Username `{model.Username}` must be between {UserMinLength} and {UserDefaultMaxLength} symbols.");
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

        public ICollection<string> ValidateRepository(CreateRepositoryInputModel model)
        {
            var errors = new List<string>();
            if (model.Name.Length < RepositoryNameMinLength || model.Name.Length > RepositoryNameMaxLength)
            {
                errors.Add($"Repository {model.Name} must be between {RepositoryNameMinLength} and {RepositoryNameMaxLength} symbols.");
            }
            return errors;
        }

        public ICollection<string> ValidateCommit(CreateCommitInputModel model)
        {
            var errors = new List<string>();
            if (model.Description.Length < CommitDescriptionMinLength)
            {
                errors.Add($"Description {model.Description} must be more than {CommitDescriptionMinLength} symbols.");
            }
            return errors;
        }
    }
}

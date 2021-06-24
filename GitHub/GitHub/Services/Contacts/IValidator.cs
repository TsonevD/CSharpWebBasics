using System.Collections.Generic;
using GitHub.Models.Commits;
using GitHub.Models.Repositories;
using GitHub.Models.Users;

namespace GitHub.Services.Contacts
{
    public interface IValidator
    {
        ICollection<string> ValidateRegistration(UserRegistrationViewModel model);

        ICollection<string> ValidateLogin(UserLoginViewModel model);

        ICollection<string> ValidateRepository(CreateRepositoryInputModel model);

        ICollection<string> ValidateCommit(CreateCommitInputModel model);

    }
}

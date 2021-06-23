using System.Collections.Generic;
using BattleCards.Models;

namespace BattleCards.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateRegistration(UserRegistrationViewModel model);

        ICollection<string> ValidateLogin(UserLoginViewModel model);



    }
}

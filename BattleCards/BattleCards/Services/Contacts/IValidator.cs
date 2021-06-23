using System.Collections.Generic;
using BattleCards.Models;
using BattleCards.Models.Cards;

namespace BattleCards.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateRegistration(UserRegistrationViewModel model);
        ICollection<string> ValidateLogin(UserLoginViewModel model);
        ICollection<string> ValidateNewCard(AddNewCadInputModel model);

    }
}

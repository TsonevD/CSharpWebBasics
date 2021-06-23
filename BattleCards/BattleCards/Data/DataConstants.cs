namespace BattleCards.Data
{
   public class DataConstants
    {
		
        public const int UserDefaultMaxLength = 20;
        public const int UserMinLength = 5;
        public const int PasswordMinLength = 6;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";


        public const int CardNameMinLength = 5;
        public const int CardNameMaxLength = 15;
        public const int CardHealthAndAttackMinLength = 0;
        public const int CardDescriptionMaxLength = 200;





    }
}

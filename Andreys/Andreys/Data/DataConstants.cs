namespace Andreys.Data
{
   public class DataConstants
    {
        public const int UserMinLength = 4;
        public const int UserMaxLength = 10;

        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int NameMinLength = 4;
        public const int NameMaxLength = 20;
        public const int DescriptionMaxLength = 10;
    }
}

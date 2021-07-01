namespace CarShop.Data
{
    public class DataConstants
    {
        public const int UserValidationMaxLength = 20;
        public const int UsernameMinLength = 4;
        public const int UserPasswordMinLength = 5;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string UserTypeMechanic = "Mechanic";
        public const string UserTypeClient = "Client";

        public const int CarModelDefaultMaxLength = 20;
        public const int CarModelDefaultMinLength = 5;
        public const int CarPlateNumberMaxlength = 8;
        public const string CarPlateNumberRegularExpression = "[A-Z]{2}[0-9]{4}[A-Z]{2}";

        public const int IssueDescriptionMinLength = 5;
    }
}

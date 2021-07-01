using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using SharedTrip.Data;
using SharedTrip.Services.Contacts;
using SharedTrip.ViewModels.Trips;
using SharedTrip.ViewModels.Users;

namespace SharedTrip.Services
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

        public ICollection<string> ValidateTrip(AddTripInputModel model)
        {
            var errors = new List<string>();
            DateTime dateValue;
            var date = DateTime.TryParseExact(model.DepartureTime, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
            if (model.Seats < SeatsMinValue || model.Seats > SeatsMaxValue)
            {
                errors.Add($"The number of free seats should be between {SeatsMinValue} and {SeatsMaxValue}");
            }
            if (model.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"The trip Description cannot be more than {DescriptionMaxLength} symbols.");
            }
            if (!date)
            {
                errors.Add($"The Departure Time should be in format {DateFormat}");
            }
            return errors;
        }
    }
}

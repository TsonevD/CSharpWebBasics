using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Data.Models
{
    using static DataConstants;

    public class User
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserValidationMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        public bool IsMechanic { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Data.Models
{
    using static DataConstants;
    public class User
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserMaxLength)]
        public string Username { get; init; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

   
    }
}


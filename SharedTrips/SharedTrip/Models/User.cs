using System;
using System.ComponentModel.DataAnnotations;
using SharedTrip.Data;

namespace SharedTrip.Models
{
    using static DataConstants;
    public class User
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(UserDefaultMaxLength)]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

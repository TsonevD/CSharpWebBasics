using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data.Models
{
    using static DataConstants;
    public class User
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserDefaultMaxLength)]
        public string Username { get; init; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public ICollection<UserCard> UserCards { get; set; } = new HashSet<UserCard>();
    }
}


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data.Models
{
    using static DataConstants;

    public class Card
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CardNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        [MinLength(CardHealthAndAttackMinLength)]
        public int Attack { get; set; }

        [MinLength(CardHealthAndAttackMinLength)]
        public int Health { get; set; }

        [Required]
        [MaxLength(CardDescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserCard> UserCards { get; init; } = new HashSet<UserCard>();
    }
}

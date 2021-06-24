using System.ComponentModel.DataAnnotations;
using Andreys.Data.Common;

namespace Andreys.Data.Models
{
    using static DataConstants;
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public Gender Gender { get; set; }
    }
}
//•	Has an Id – int, Primary key
//•	Has a Name – a string with min length 4 and max length 20 (inclusive) (required)
//•	Has a Description – a string with max length 10 (inclusive)
//•	Has a ImageUrl – a string
//•	Has a Price – a decimal (required)
//•	Has a Category – an Enum – option between (Shirt, Denim, Shorts, Jacket) (required)
//•	Has a Gender – an Enum – option between (Male and Female) (required)

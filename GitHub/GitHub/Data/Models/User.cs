using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GitHub.Data.Models
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

        public IEnumerable<Repository> Repositories { get; init; } = new List<Repository>();
        public IEnumerable<Commit> Commits { get; init; } = new List<Commit>();


    }
}
//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email - a string (required)
//•	Has a Password – a string with min length 6 and max length 20  - hashed in the database (required)
//•	Has Repositories collection – a Repository type
//•	Has Commits collection – a Commit type


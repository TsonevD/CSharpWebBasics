using System;
using GitHub.Data.Models;

namespace GitHub.Models.Repositories
{
    public class AllRepositoriesViewModel
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Owner { get; init; }
        public DateTime CreatedOn { get; init; }
        public int CommitsCount { get; init; }

    }
}

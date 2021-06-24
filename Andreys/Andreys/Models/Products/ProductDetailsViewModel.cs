namespace Andreys.Models.Products
{
    public class ProductDetailsViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public string Description { get; init; }

        public string ImageUrl { get; init; }

        public string Category { get; init; }

        public string Gender { get; init; }

        public decimal Price { get; init; }
    }
}

namespace FloristKami.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public string Image { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
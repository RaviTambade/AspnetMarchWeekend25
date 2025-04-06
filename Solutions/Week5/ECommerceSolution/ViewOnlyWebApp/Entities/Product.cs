namespace ViewOnlyWebApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        // Constructor
        public Product(int id, string name, string description, decimal price, string category, string imageUrl, bool isAvailable)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            ImageUrl = imageUrl;
            IsAvailable = isAvailable;
        }
    }
}

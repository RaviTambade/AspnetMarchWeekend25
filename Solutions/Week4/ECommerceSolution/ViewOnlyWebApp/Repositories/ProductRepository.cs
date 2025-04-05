
using ViewOnlyWebApp.Entities;
namespace ViewOnlyWebApp.Repositories
{
    public class ProductRepository: IProductRepository
    {
        // In-memory list of products
        private List<Product> products = new List<Product>
        {

            new Product(1, "Gerbera", "A beautiful flower", 10.99m, "Flowers", "/images/gerbera.jpg", true),
            new Product(2, "Rose", "A classic flower", 12.99m, "Flowers", "/images/rose.jpg", true),
            new Product(3, "Lotus", "A serene flower", 15.99m, "Flowers", "/images/lotus.jpg", true)
        };
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
                existingProduct.ImageUrl = product.ImageUrl;
                existingProduct.IsAvailable = product.IsAvailable;
            }
        }
        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                products.Remove(product);
            }
        }
    }
     
}

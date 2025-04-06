using ViewOnlyWebApp.Entities;
namespace ViewOnlyWebApp.Services
{
    public interface IProductService
    {
        // Method to get all products
        IEnumerable<Product> GetAllProducts();
        // Method to get a product by its ID
        Product GetProductById(int id);
        // Method to add a new product
        void AddProduct(Product product);
        // Method to update an existing product
        void UpdateProduct(Product product);
        // Method to delete a product by its ID
        void DeleteProduct(int id);
    }
}

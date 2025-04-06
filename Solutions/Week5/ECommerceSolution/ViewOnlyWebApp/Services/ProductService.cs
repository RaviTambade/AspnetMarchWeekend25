using ViewOnlyWebApp.Entities;
using ViewOnlyWebApp.Repositories;

namespace ViewOnlyWebApp.Services
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);

        }

        public void DeleteProduct(int id)
        {

            productRepository.DeleteProduct(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();

        }

        public Product GetProductById(int id)
        {
            return productRepository.GetProductById(id);

        }

        public void UpdateProduct(Product product)
        {

            productRepository.UpdateProduct(product);
        }
    }
}

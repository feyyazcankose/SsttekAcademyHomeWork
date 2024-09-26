using SsttekAcademyHomeWork.Models.Repositories;

namespace SsttekAcademyHomeWork.Models.Services
{
    public class ProductService
    {
        private readonly ProductRepository productRepository = new ProductRepository();

        public List<Product> GetProducts()
        {
            return productRepository.GetProducts();
        }
    }
}
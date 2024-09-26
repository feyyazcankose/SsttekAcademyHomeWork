using SsttekAcademyHomeWork.Models.Repositories;

namespace SsttekAcademyHomeWork.Models.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}
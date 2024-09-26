using SsttekAcademyHomeWork.Models.Repositories.Products;

namespace SsttekAcademyHomeWork.Models.Services.Products
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
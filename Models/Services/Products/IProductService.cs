using SsttekAcademyHomeWork.Models.Repositories.Products;

namespace SsttekAcademyHomeWork.Models.Services.Products
{
    public interface IProductService
    {
        public List<Product> GetProducts();
    }
}
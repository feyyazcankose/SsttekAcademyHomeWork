namespace SsttekAcademyHomeWork.Models.Repositories.Products
{
    public class ProductRepository:IProductRepository
    {
        private static List<Product> products = new();

        static ProductRepository()
        {
            products.Add(new Product() { Id = 1, Name = "Product 1", Description = "Description 1", Price = 100 });
            products.Add(new Product() { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200 });
            products.Add(new Product() { Id = 3, Name = "Product 3", Description = "Description 3", Price = 300 });
            products.Add(new Product() { Id = 4, Name = "Product 4", Description = "Description 4", Price = 400 });
            products.Add(new Product() { Id = 5, Name = "Product 5", Description = "Description 5", Price = 500 });
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
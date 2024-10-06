using WebAPI_With_Dapper.Models;

namespace WebAPI_With_Dapper.Interfaces
{
    public interface IProduct
    {
        Task<int> AddProductAsync(Product product);
        Task<int> UpdateProductAsync(Product product);
        Task<int> DeleteProductAsync(int productId);
        Task<Product> GetProductByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}

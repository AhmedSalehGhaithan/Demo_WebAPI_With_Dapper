using Dapper;
using System.Data;
using System.Data.Common;
using WebAPI_With_Dapper.Interfaces;
using WebAPI_With_Dapper.Models;
namespace WebAPI_With_Dapper.Implementation
{
    public class ProductRepository(IDbConnection _connection) : IProduct
    {
        public async Task<int> AddProductAsync(Product product)
        {
            var query = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";
            return await _connection.ExecuteAsync(query, product);
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var query = "DELETE FROM Product WHERE Id = @Id";
            return await _connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var query = "SELECT * FROM Product";
            return await _connection.QueryAsync<Product>(query);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var query = "SELECT * FROM Product WHERE Id = @Id";
            return await _connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            var query = "UPDATE Product SET Name = @Name, Price = @Price WHERE Id = @Id";
            return await _connection.ExecuteAsync(query, product);
        }
    }
}

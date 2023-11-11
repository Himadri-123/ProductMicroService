using Dapper;
using ProductMicroService.Entities;

namespace ProductMicroService.Service
{
	public class ProductService
	{
		private readonly DapperContext _context;
		public ProductService(DapperContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Product>> GetProduct()
		{
			var query = "Select * From Product;";

			using (var connection = _context.CreateConnection())
			{
				var Products = await connection.QueryAsync<Product>(query);
				return Products.ToList();
			}
		}
	}
}

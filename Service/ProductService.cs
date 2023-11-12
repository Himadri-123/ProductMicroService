using Dapper;
using ProductMicroService.Entities;
using ProductMicroService.Entities.Request;
using ProductMicroService.Entities.Response;
using System.Data;

namespace ProductMicroService.Service
{
	public class ProductService
	{
		private readonly DapperContext _context;
		public ProductService(DapperContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ProductResponse>> GetProductAsync()
		{
			var query = "SELECT * FROM Product;";

			using (var connection = _context.CreateConnection())
			{
				var Products = await connection.QueryAsync<ProductResponse>(query);
				return Products.ToList();
			}
		}

		public async Task<IEnumerable<ProductResponse>> GetProductByIdAsync(int id)
		{
			var query = "SELECT * FROM Product WHERE P_ID = " + id;

			using (var connection = _context.CreateConnection())
			{
				var Products = await connection.QueryAsync<ProductResponse>(query);
				return Products.ToList();
			}
		}

		public async Task<IEnumerable<ProductResponse>> CreateProductAsync(ProductRequest product)
		{
			try
			{
				var query = "INSERT INTO Product (P_Name, P_Description, P_ActualPrice,P_Discount,P_DiscountPrice,P_Active,P_Image,P_Service) VALUES " +
					"(@P_Name,@P_Description,@P_ActualPrice,@P_Discount,@P_DiscountPrice,@P_Active, @P_Image, @P_Service)" +
					"SELECT CAST(SCOPE_IDENTITY() as int)";
				var parameters = new
				{
					P_Name = product.P_Name,
					P_Description = product.P_Description,
					P_ActualPrice = product.P_ActualPrice,
					P_Discount = product.P_Discount,
					P_DiscountPrice = product.P_DiscountPrice,
					P_Active = product.P_Active,
					P_Image = product.P_Image,
					P_Service = product.P_Service
				};
				using (var connection = _context.CreateConnection())
				{
					var id = await connection.ExecuteAsync(query, parameters);
					
					var connection1 = _context.CreateConnection();
					var query1 = "SELECT * FROM Product WHERE P_ID = " + id;
					var Products = await connection.QueryAsync<ProductResponse>(query);
					return Products.ToList();
					
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task UpdateProductAsync(int id, ProductRequest product)
		{
			var query = "UPDATE Product SET P_Name = @P_Name, P_Description = @P_Description, P_ActualPrice = @P_ActualPrice" +
				"  P_Discount = @P_Discount ,P_DiscountPrice = @P_DiscountPrice, P_Active = @P_Active," +
				" P_Image=@P_Image, P_Service=@P_Service WHERE Id = @Id";
			
			var parameters = new
			{
				P_Name = product.P_Name,
				P_Description = product.P_Description,
				P_ActualPrice = product.P_ActualPrice,
				P_Discount = product.P_Discount,
				P_DiscountPrice = product.P_DiscountPrice,
				P_Active = product.P_Active,
				P_Image = product.P_Image,
				P_Service = product.P_Service
			};
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteProductAsync(int id)
		{
			var query = "DELETE FROM Product WHERE Id = @Id";
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, new { id });
			}
		}
	}
}

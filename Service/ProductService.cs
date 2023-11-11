namespace ProductMicroService.Service
{
	public class ProductService
	{
		private readonly DapperContext _context;
		public ProductService(DapperContext context)
		{
			_context = context;
		}
	}
}

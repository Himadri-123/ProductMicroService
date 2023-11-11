using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroService.Controllers
{
	[ApiController]
	public class ProductDetailsController : ControllerBase
	{
		private readonly ILogger<ProductDetailsController> _logger;
		private readonly ProductService _productService;
		public ProductDetailsController(ILogger<ProductDetailsController> logger, ProductService productService)
		{
			_logger = logger;
			_productService = productService;
		}
		[HttpGet]
		[Route("GetProductDetails")]
		public async Task<IActionResult> GetProduct()
		{
			try
			{
				var products = _productService.GetProduct();
				return Ok(products);
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}

		[HttpGet]
		[Route("GetProductDetailsById")]
		public async Task<IActionResult> GetProductById([FromQuery] int Id)
		{
			try
			{
				var companies = "";
				return Ok(companies);
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}

	}
}

using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Entities.Request;
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
				var products = await _productService.GetProductAsync();
				if (products == null)
					return NotFound();
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
				var products = await _productService.GetProductByIdAsync(Id);
				if (products == null)
					return NotFound();
				return Ok(products);
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}

		[HttpPost]
		[Route("CreateProductDetails")]
		public IActionResult CreateProduct([FromQuery] ProductRequest product)
		{
			try
			{
				var createdProduct = _productService.CreateProductAsync(product);
				if (createdProduct == null)
					return NotFound();
				return Ok(createdProduct);
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}

		[HttpPut()]
		[Route("UpdateProductDetails")]
		public async Task<IActionResult> UpdateProduct([FromQuery] int id, [FromQuery] ProductRequest product)
		{
			try
			{
				await _productService.UpdateProductAsync(id,product);
				return NoContent();
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}
		[HttpDelete()]
		[Route("DeleteProductDetails")]
		public async Task<IActionResult> DeleteProduct([FromQuery] int id)
		{
			try
			{
				await _productService.DeleteProductAsync(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}


	}
}

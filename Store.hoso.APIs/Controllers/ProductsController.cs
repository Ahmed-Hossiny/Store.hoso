using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.hoso.Core.Services.Interfaces;

namespace Store.hoso.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private IServices _services;
		public ProductsController(IServices services) 
		{
			_services = services;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProducts() 
		{
			var result =  await _services.GetAllProductsAsync();
			return Ok(result);	

		}
		[HttpGet("Brands")]
		public async Task<IActionResult> GetAllBrands()
		{
			var result = await _services.GetAllBrandsAsync();
			return Ok(result);

		}

		[HttpGet("Types")]
		public async Task<IActionResult> GetAllTypes()
		{
			var result = await _services.GetAllTypesAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			var result = await _services.GetProductById(id);
			return Ok(result);
		}

	}
}

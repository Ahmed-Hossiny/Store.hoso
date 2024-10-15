using Store.hoso.Core.Entites;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.hoso.APIs.DTOs;

namespace Store.hoso.Core.Services.Interfaces
{
	public interface IServices
	{
		Task<IEnumerable<ProductDTO>>GetAllProductsAsync();
		Task<IEnumerable<ProductBrandDTO>> GetAllBrandsAsync();
		Task<IEnumerable<ProductTypeDTo>> GetAllTypesAsync();

		Task<ProductDTO> GetProductById(int id);


	}
}

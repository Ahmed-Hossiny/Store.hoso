using AutoMapper;
using Store.hoso.APIs.DTOs;
using Store.hoso.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.hoso.Core.Maaping.Products
{
	public class ProductProfile:Profile
	{

		public ProductProfile() 
		{
			CreateMap<Product, ProductDTO>().ForMember(d=>d.BrandName,options=>options.MapFrom(s=>s.Brand.Name))
				                            .ForMember(d=>d.TypeName,options=>options.MapFrom(s=>s.Type.Name));
			CreateMap<ProductBrand, ProductBrandDTO>();
			CreateMap<ProductType, ProductTypeDTo>();
		}

	}
}

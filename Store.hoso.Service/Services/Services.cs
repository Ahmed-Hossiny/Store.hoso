using AutoMapper;
using Store.hoso.APIs.DTOs;
using Store.hoso.Core.Entites;
using Store.hoso.Core.Repositories.Interfaces;
using Store.hoso.Core.Services.Interfaces;
using Store.hoso.Repository.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.hoso.Service.Services
{
	public class Services : IServices
	{
		private IUnitOfWork _unitOfWork;
		private IMapper _mapper;
		public Services(  IUnitOfWork unitOfWork,IMapper mapper) 
		{
			
			_unitOfWork = unitOfWork;
			_mapper = mapper;	
		}	
		public async Task<IEnumerable<ProductBrandDTO>> GetAllBrandsAsync()
		{
			return  _mapper.Map<IEnumerable<ProductBrandDTO>>(await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync());
		}

		public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
		{
			return _mapper.Map<IEnumerable<ProductDTO>>( await _unitOfWork.Repository<Product, int>().GetAllAsync());
		}

		public async Task<IEnumerable<ProductTypeDTo>> GetAllTypesAsync()
		{
			return _mapper.Map<IEnumerable<ProductTypeDTo>>(await _unitOfWork.Repository<ProductType, int>().GetAllAsync());
		}

		public async Task<ProductDTO> GetProductById(int id)
		{
			return _mapper.Map<ProductDTO>(await _unitOfWork.Repository<Product, int>().GetByIdAsync(id));
		}
	}
}


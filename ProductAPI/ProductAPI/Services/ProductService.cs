using ProductAPI.Models.DTO;
using ProductAPI.Repositories;

namespace ProductAPI.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository= productRepository;
		}
		public IEnumerable<ProductDto> GetProducts()
		{
			var productEntities = _productRepository.GetProducts();

			if (productEntities == null)
			{
				return Enumerable.Empty<ProductDto>();
			}

			return  productEntities
			.Select(s => new ProductDto
			{
				Id = s.ProductId,
				Description = s.ProductDescription,
				CurrentPrice = s.ProductCurrentPrice,
				Name= s.ProductName,
				LastUpdated = s.ProductLastUpdated.Value
			});
		}
	}
}

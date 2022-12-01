using ProductAPI.Models.DTO;

namespace ProductAPI.Services
{
	public interface IProductService
	{
		public IEnumerable<ProductDto> GetProducts();
	}
}

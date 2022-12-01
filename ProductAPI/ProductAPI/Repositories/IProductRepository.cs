using ProductAPI.Models.Business;

namespace ProductAPI.Repositories
{
	public interface IProductRepository
	{
		public IEnumerable<ProductEntity> GetProducts();
	}
}

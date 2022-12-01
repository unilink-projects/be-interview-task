using System.Diagnostics.CodeAnalysis;

using AutoFixture;

using ProductAPI.Models.Business;

namespace ProductAPI.Repositories
{
	[ExcludeFromCodeCoverage]
	public class ProductRepository : IProductRepository
	{
		private readonly Fixture _fixture = new();
		public IEnumerable<ProductEntity> GetProducts()
		{
			return new List<ProductEntity>()
			{
				_fixture.Create<ProductEntity>(),
				_fixture.Create<ProductEntity>(),
				_fixture.Build<ProductEntity>()
				.Without(x => x.ProductLastUpdated)
				.Create()
			};
		}
	}
}

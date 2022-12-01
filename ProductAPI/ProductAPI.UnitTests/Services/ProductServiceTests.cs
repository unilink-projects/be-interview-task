using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoFixture;

using Moq;

using ProductAPI.Models.Business;
using ProductAPI.Repositories;
using ProductAPI.Services;

namespace ProductAPI.UnitTests.Services
{
	public class ProductServiceTests
	{
		private readonly Fixture _fixture = new();
		private readonly Mock<IProductRepository> _productRepo = new(MockBehavior.Strict);

		private readonly ProductService _productService;

		public ProductServiceTests()
		{
			_productService = new ProductService(_productRepo.Object);
		}

		[Fact]
		public void GetProducts_RepoReturnsNull()
		{
			_productRepo.Setup(x => x.GetProducts())
				.Returns(Enumerable.Empty<ProductEntity>());

			var products = _productService.GetProducts();

			Assert.Empty(products);

			_productRepo.Verify(x => x.GetProducts(), Times.Once);
		}

		[Fact]
		public void GetAllProducts_RepoReturnsEntities() 
		{ 
			var productEntities = _fixture.CreateMany<ProductEntity>();

			_productRepo.Setup(x => x.GetProducts())
				.Returns(productEntities);

			var products = _productService.GetProducts();

			Assert.NotEmpty(products);

			foreach(var productEntity in productEntities)
			{
				Assert.Contains(productEntity.ProductName, products.Select(x => x.Name));
				Assert.Contains(productEntity.ProductId, products.Select(x => x.Id));
			}

			_productRepo.Verify(x => x.GetProducts(), Times.Once);
		}
	}
}

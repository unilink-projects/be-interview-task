using AutoFixture;

using Microsoft.AspNetCore.Mvc;

using Moq;

using ProductAPI.Controllers;
using ProductAPI.Models.DTO;
using ProductAPI.Services;

namespace ProductAPI.UnitTests.Controllers
{
	public class ProductControllerTests
	{
		private readonly Fixture _fixture = new();
		private readonly Mock<IProductService> _productService = new (MockBehavior.Strict);

		private readonly ProductsController _controller;

		public ProductControllerTests()
		{
			_controller = new ProductsController(_productService.Object);
		}

		[Fact]
		public void GetProducts()
		{
			var products = _fixture.CreateMany<ProductDto>();

			_productService.Setup(x => x.GetProducts())
				.Returns(products);

			var result = _controller.GetProducts();

			Assert.NotNull(result);
			Assert.IsType<OkObjectResult>(result);
			OkObjectResult okResult = (OkObjectResult)result;

			Assert.NotNull(okResult.Value);
			Assert.IsAssignableFrom<IEnumerable<ProductDto>>(okResult.Value);

			var returnedProducts = (IEnumerable<ProductDto>)okResult.Value;

			foreach(var product in products)
			{
				Assert.Contains(product.Name, returnedProducts.Select(x => x.Name));
			}

			_productService.Verify(x => x.GetProducts(), Times.Once);
		}
	}
}

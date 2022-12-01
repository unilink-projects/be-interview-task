using System.Diagnostics.CodeAnalysis;

namespace ProductAPI.Models.Business
{
	[ExcludeFromCodeCoverage]
	public class ProductEntity
	{
		public long ProductId { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public string ProductDescription { get; set; } = string.Empty;
		public decimal ProductCurrentPrice { get; set; }
		public DateTime? ProductLastUpdated { get; set; }
		public string LastUpdatedUser { get; set; } = string.Empty;
	}
}

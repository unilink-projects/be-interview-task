namespace ProductAPI.Models.DTO
{
	public class ProductDto
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal CurrentPrice { get; set; }
		public DateTime LastUpdated { get; set; } = DateTime.MinValue;
	}
}

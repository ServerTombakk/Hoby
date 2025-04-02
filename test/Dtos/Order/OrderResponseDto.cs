using test.Entities;

namespace test.Dtos.Order
{
	public class OrderResponseDto
	{
		public string UserName { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public double TotalPrice { get; set; }
	}
}

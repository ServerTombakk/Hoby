using test.Entities;

namespace test.Dtos.Order
{
	public class CreateOrderDto
	{
		public int UserId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public double TotalPrice { get; set; }
	}
}

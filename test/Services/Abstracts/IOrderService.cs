using test.Dtos.Order;
using test.Results;

namespace test.Services.Abstracts
{
	public interface IOrderService
	{
		Task<Result> CreateOrder(CreateOrderDto createOrderDto);
		Task<Result> Delete(int id);
		Task<DataResult<OrderResponseDto>> Get(int id);
		Task<DataResult<IEnumerable<OrderResponseDto>>> GetAll(); 
	}
}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Dtos.Order;
using test.Results;
using test.Services.Abstracts;
using test.Services.Concretes;

namespace test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet("Detail")]
		public async Task<ActionResult<Result>> Detail(int id)
		{
			DataResult<OrderResponseDto> response = await _orderService.Get(id);
			return response;
		}


		[HttpGet("GetAll")]
		public async Task<ActionResult<Result>> GetAll()
		{
			var response = await _orderService.GetAll();
			return response;
		}

		[HttpPost("Create")]
		public async Task<ActionResult<Result>> Create(CreateOrderDto createOrderDto)
		{
			var response = await _orderService.CreateOrder(createOrderDto);
			return response;
		}
	}
}

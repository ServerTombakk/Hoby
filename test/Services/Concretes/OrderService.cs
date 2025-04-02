using AutoMapper;
using Microsoft.EntityFrameworkCore;
using test.Data.Abstracts;
using test.Dtos.Order;
using test.Entities;
using test.Results;
using test.Services.Abstracts;

namespace test.Services.Concretes
{
	public class OrderService : IOrderService
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;
		private readonly IProductRepository _productRepository;
		private readonly IUserRepository _userRepository;
		public OrderService(IMapper mapper, IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
		{
			_mapper = mapper;
			_orderRepository = orderRepository;
			_productRepository = productRepository;
			_userRepository = userRepository;
			DataSeed();
		}
		private void DataSeed()
		{
			if(_productRepository.GetAll().Count() == 0)
			{
				Product product = new Product
				{
					Name = "Phone",
					Price = 20000.00,
					Stock = 4
				};

				_productRepository.Add(product);
			}
			if (_userRepository.GetAll().Count() == 0)
			{
				User user = new User
				{
					Name = "Server",
					Email = "Server78135@gmail.com"
				};

				_userRepository.Add(user);
			}

		}
		public async Task<Result> CreateOrder(CreateOrderDto createOrderDto)
		{
			Order order = _mapper.Map<Order>(createOrderDto);
			Product product =await _productRepository.GetAsync(x => x.Id == createOrderDto.ProductId);
			if (product.Stock < createOrderDto.Quantity)
			{
				return new ErrorResult("We can provide only "+ product.Stock + " sorry, update order quantity and try again");
			}
			await _orderRepository.AddAsync(order);

			product.Stock -= createOrderDto.Quantity;
			await _productRepository.UpdateAsync(product);
			return new SuccessResult("Order Has been Created Successfully");
		}

		public async Task<Result> Delete(int id)
		{
			Order order = await _orderRepository.GetAsync(x => x.Id ==id);
			if(order == null)
			{
				return new ErrorResult("Order Could not be found");
			}
			await _orderRepository.DeleteAsync(order);
			return new SuccessResult("Order deleted Successfully");
		}

		public async Task<DataResult<OrderResponseDto>> Get(int id)
		{
			Order order = await  _orderRepository.GetAsync(x => x.Id == id,
				include: query => query.Include(x => x.User).Include(x => x.Product));
			if(order == null)
			{
				return new ErrorDataResult<OrderResponseDto>("Order Could not be found");
			}

			OrderResponseDto orderResponseDto = _mapper.Map<OrderResponseDto>(order);

			return new SuccessDataResult<OrderResponseDto>(orderResponseDto,"Order Getted");
		}

		public async Task<DataResult<IEnumerable<OrderResponseDto>>> GetAll()
		{
			IEnumerable<Order> orders = await _orderRepository.GetAllAsync(include: query => query.Include(x => x.User).Include(x => x.Product));
			if (orders == null)
			{
				return new ErrorDataResult<IEnumerable<OrderResponseDto>>("Order Could not be found");
			}

			IEnumerable<OrderResponseDto> orderResponseDto = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);

			return new SuccessDataResult<IEnumerable<OrderResponseDto>>(orderResponseDto, "Order Getted");
		}
	}
}

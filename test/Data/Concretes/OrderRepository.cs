﻿using test.Data.Abstracts;
using test.Entities;

namespace test.Data.Concretes
{
	public class OrderRepository : GenericRepository<Order, ApplicationDbContext>, IOrderRepository
	{
		public OrderRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}

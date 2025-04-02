using test.Data.Abstracts;
using test.Entities;

namespace test.Data.Concretes
{
	public class ProductRepository : GenericRepository<Product, ApplicationDbContext>, IProductRepository
	{
		public ProductRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}

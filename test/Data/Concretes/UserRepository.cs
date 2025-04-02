using test.Data.Abstracts;
using test.Entities;

namespace test.Data.Concretes
{
	public class UserRepository : GenericRepository<User, ApplicationDbContext>, IUserRepository
	{
		public UserRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}

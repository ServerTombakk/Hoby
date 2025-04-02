namespace test.Data
{
	public interface IQuery<T>
	{
		IQueryable<T> Query();
	}
}

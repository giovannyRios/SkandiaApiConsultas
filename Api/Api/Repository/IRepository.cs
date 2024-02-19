
namespace Api.Repository
{
	public interface IRepository<TEntity>
	{
		public Task<IEnumerable<TEntity>> GetAll();
	}
}

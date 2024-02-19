using Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
	public class Repository<TEntity>:IRepository<TEntity> where TEntity : class
	{
		private readonly AcmeDbContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public Repository(AcmeDbContext context)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await _dbSet.ToListAsync();
		}
	}	
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Repository
{
	public interface IRepository<TEntity, TId>
	{
		IEnumerable<TEntity> Get();

		TEntity Get(TId id);

		TId Insert(TEntity entity);

		bool Update(TId id, TEntity entity);
	}
}

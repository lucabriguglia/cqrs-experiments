using System.Threading.Tasks;
using Weapsy.Blog.Bus.Contracts;
using Weapsy.Blog.Queries.Contracts;

namespace Weapsy.Blog.Bus
{
	public class QueryDispatcher : IQueryDispatcher
	{
		public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery
		{
			return default(TResult);
		}
	}
}

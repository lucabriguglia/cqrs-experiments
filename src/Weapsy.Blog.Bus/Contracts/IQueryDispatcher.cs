using System.Threading.Tasks;
using Weapsy.Blog.Queries.Contracts;

namespace Weapsy.Blog.Bus.Contracts
{
	public interface IQueryDispatcher<TQuery, TResult> where TQuery : IQuery
	{
		TResult Dispatch(TQuery query);
		Task<TResult> DispatchAsync(TQuery query);
	}
}

using System.Threading.Tasks;
using Weapsy.Blog.Queries.Contracts;

namespace Weapsy.Blog.Bus.Contracts
{
	public interface IQueryDispatcher
	{
		Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery;
	}
}

using System;
using System.Threading.Tasks;
using Weapsy.Blog.Bus.Contracts;
using Weapsy.Blog.Queries.Contracts;
using Weapsy.Blog.Queries.Handlers.Contracts;

namespace Weapsy.Blog.Bus
{
	public class QueryDispatcher : IQueryDispatcher
	{
		public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery
		{
			return default(TResult);
			//var handler = _kernel.Resolve<IQueryHandler<TQuery, TResult>>();
			//return await handler.Retrieve(query);
		}
	}
}

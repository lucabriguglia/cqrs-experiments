using System;
using System.Threading.Tasks;
using Weapsy.Blog.Bus.Contracts;
using Weapsy.Blog.Queries.Contracts;
using Weapsy.Blog.Queries.Handlers.Contracts;

namespace Weapsy.Blog.Bus
{
	public class QueryDispatcher : IQueryDispatcher<IQuery, object>
	{
		public object Dispatch(IQuery query)
		{
			throw new NotImplementedException();
		}

		public Task<object> DispatchAsync(IQuery query)
		{
			throw new NotImplementedException();
		}
	}
}

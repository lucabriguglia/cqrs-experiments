using System.Threading.Tasks;
using Weapsy.Blog.Queries.Contracts;

namespace Weapsy.Blog.Queries.Handlers.Contracts
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> Retrieve(TQuery query);
    }
}
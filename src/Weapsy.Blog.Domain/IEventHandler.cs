using System.Threading.Tasks;

namespace Weapsy.Blog.Domain
{
    public interface IEventHandler<TEvent> where TEvent : IDomainEvent
    {
		Task Execute(TEvent @event);
    }
}

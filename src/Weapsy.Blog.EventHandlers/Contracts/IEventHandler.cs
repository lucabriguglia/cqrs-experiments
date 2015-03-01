using Weapsy.Blog.Events.Contracts;

namespace Weapsy.Blog.EventHandlers.Contracts
{
    public interface IEventHandler<TEvent> where TEvent : IDomainEvent
    {
        void Execute(TEvent @event);
    }
}

namespace Weapsy.Blog.Domain
{
    public interface IEventHandler<TEvent> where TEvent : IDomainEvent
    {
        void Execute(TEvent @event);
    }
}

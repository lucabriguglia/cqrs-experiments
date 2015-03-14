using System.Threading.Tasks;
using Weapsy.Blog.Domain;

namespace Weapsy.Blog.Bus.Contracts
{
	public interface IEventPublisher
	{
		void Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent;
		Task PublishAsync<TEvent>(TEvent @event) where TEvent : IDomainEvent;
	}
}

using System.Threading.Tasks;
using Weapsy.Blog.Domain;

namespace Weapsy.Blog.Bus.Contracts
{
	public interface IEventPublisher<T> where T : IDomainEvent
	{
		void Publish(T @event);
		Task PublishAsync(T @event);
	}
}

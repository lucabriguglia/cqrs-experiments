using System;
using System.Threading.Tasks;
using Weapsy.Blog.Bus.Contracts;
using Weapsy.Blog.Domain;

namespace Weapsy.Blog.Bus
{
	public class EventPublisher : IEventPublisher
	{
		public void Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent
		{
			throw new NotImplementedException();
		}

		public Task PublishAsync<TEvent>(TEvent @event) where TEvent : IDomainEvent
		{
			return new TaskFactory().StartNew(() => Publish(@event));
		}
	}
}

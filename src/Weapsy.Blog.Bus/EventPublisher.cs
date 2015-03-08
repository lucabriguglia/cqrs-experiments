using System;
using System.Threading.Tasks;
using Weapsy.Blog.Bus.Contracts;
using Weapsy.Blog.Domain;

namespace Weapsy.Blog.Bus
{
	public class EventPubisher : IEventPublisher<IDomainEvent>
	{
		public void Publish(IDomainEvent @event)
		{
			throw new NotImplementedException();
		}

		public Task PublishAsync(IDomainEvent @event)
		{
			return new TaskFactory().StartNew(() => Publish(@event));
		}
	}
}

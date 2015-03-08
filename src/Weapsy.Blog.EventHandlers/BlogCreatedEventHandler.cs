using System;
using System.Threading.Tasks;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Blog.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class BlogCreatedEventHandler : IEventHandler<BlogCreatedEvent>
	{
		public Task Execute(BlogCreatedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
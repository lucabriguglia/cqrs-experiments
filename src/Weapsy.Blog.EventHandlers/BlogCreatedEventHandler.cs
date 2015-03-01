using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Blog.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class BlogCreatedEventHandler : IEventHandler<BlogCreatedEvent>
	{
		public void Execute(BlogCreatedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
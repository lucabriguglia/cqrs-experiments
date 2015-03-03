using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Post.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class PostCreatedEventHandler : IEventHandler<PostCreatedEvent>
	{
		public void Execute(PostCreatedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Posts;
using Weapsy.Blog.Domain.Posts.Events;

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
using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Posts;
using Weapsy.Blog.Domain.Posts.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class PostPublishedEventHandler : IEventHandler<PostPublishedEvent>
	{
		public void Execute(PostPublishedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
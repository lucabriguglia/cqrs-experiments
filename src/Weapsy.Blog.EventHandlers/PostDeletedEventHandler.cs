using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Posts;
using Weapsy.Blog.Domain.Posts.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class PostDeletedEventHandler : IEventHandler<PostDeletedEvent>
	{
		public void Execute(PostDeletedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
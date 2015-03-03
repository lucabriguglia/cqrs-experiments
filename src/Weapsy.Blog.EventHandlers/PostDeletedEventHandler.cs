using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Post.Events;

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
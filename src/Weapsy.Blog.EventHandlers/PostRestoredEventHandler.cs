using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Post.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class PostRestoredEventHandler : IEventHandler<PostRestoredEvent>
	{
		public void Execute(PostRestoredEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
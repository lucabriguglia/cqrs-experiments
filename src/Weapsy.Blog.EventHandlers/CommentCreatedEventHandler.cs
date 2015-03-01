using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Comment.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class CommentCreatedEventHandler : IEventHandler<CommentCreatedEvent>
	{
		public void Execute(CommentCreatedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
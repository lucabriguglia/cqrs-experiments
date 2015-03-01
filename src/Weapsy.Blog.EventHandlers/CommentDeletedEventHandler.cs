using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Comment.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class CommentDeletedEventHandler : IEventHandler<CommentDeletedEvent>
	{
		public void Execute(CommentDeletedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
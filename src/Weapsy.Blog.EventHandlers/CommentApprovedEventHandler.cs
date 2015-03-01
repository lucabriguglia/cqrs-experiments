using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Comment.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class CommentApprovedEventHandler : IEventHandler<CommentApprovedEvent>
	{
		public void Execute(CommentApprovedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
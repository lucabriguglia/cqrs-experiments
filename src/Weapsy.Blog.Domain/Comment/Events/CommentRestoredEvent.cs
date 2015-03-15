using System;

namespace Weapsy.Blog.Domain.Comment.Events
{
	public class CommentRestoredEvent : IDomainEvent
	{
		public Guid Id { get; private set; }

		public CommentRestoredEvent(Guid id)
		{
			Id = id;
		}
	}
}

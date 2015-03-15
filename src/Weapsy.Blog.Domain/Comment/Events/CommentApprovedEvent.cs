using System;

namespace Weapsy.Blog.Domain.Comment.Events
{
	public class CommentApprovedEvent : IDomainEvent
	{
		public Guid Id { get; private set; }

		public CommentApprovedEvent(Guid id)
		{
			Id = id;
		}
	}
}

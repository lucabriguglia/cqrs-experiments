using System;

namespace Weapsy.Blog.Domain.Comment.Events
{
	public class CommentCreatedEvent : IDomainEvent
	{
		public Guid PostId { get; private set; }
		public string Text { get; private set; }
		public bool Approved { get; private set; }

		public CommentCreatedEvent(Guid postId, string text, bool approved)
		{
			PostId = postId;
			Text = text;
			Approved = approved;
		}
	}
}

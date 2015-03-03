using System;

namespace Weapsy.Blog.Domain.Post.Events
{
    public class PostRestoredEvent : IDomainEvent
    {
		public Guid Id { get; private set; }

		public PostRestoredEvent(Guid id)
		{
			Id = id;
		}
	}
}

using System;

namespace Weapsy.Blog.Domain.Posts.Events
{
    public class PostDeletedEvent : IDomainEvent
    {
		public Guid Id { get; private set; }

		public PostDeletedEvent(Guid id)
		{
			Id = id;
		}
	}
}

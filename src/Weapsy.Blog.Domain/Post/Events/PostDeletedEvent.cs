using System;

namespace Weapsy.Blog.Domain.Post.Events
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

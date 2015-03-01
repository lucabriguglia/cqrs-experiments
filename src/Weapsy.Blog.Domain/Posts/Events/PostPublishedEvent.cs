using System;

namespace Weapsy.Blog.Domain.Posts.Events
{
    public class PostPublishedEvent : IDomainEvent
    {
		public Guid Id { get; private set; }

		public PostPublishedEvent(Guid id)
		{
			Id = id;
		}
	}
}

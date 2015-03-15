using System;

namespace Weapsy.Blog.Domain.Blog.Events
{
	public class BlogRestoredEvent : IDomainEvent
	{
		public Guid Id { get; private set; }

		public BlogRestoredEvent(Guid id)
		{
			Id = id;
		}
	}
}

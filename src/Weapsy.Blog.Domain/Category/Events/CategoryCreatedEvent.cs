using System;

namespace Weapsy.Blog.Domain.Category.Events
{
    public class CategoryCreatedEvent : IDomainEvent
    {
		public Guid BlogId { get; private set; }
		public Guid Id { get; private set; }
		public string Title { get; private set; }

		public CategoryCreatedEvent(Guid blogId, Guid id, string title)
		{
			BlogId = blogId;
			Id = id;
			Title = title;
		}
	}
}

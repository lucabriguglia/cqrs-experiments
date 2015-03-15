using System;

namespace Weapsy.Blog.Domain.Category.Events
{
	public class CategoryTitleChangedEvent : IDomainEvent
	{
		public Guid Id { get; private set; }
		public string Title { get; private set; }

		public CategoryTitleChangedEvent(Guid id, string title)
		{
			Id = id;
			Title = title;
		}
	}
}

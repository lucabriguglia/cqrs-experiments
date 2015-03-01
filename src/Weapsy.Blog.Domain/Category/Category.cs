using System;
using Weapsy.Blog.Domain.Category.Events;

namespace Weapsy.Blog.Domain.Category
{
    public class Category : AggregateRoot
    {
        public Guid BlogId { get; private set; }
        public string Title { get; private set; }

        public Category()
        {
            Id = Guid.Empty;
        }

        private Category(Guid blogId, string title) : this()
        {
            BlogId = blogId;
            Title = title;

            Id = Guid.NewGuid();
            MarkNew();

			Events.Add(new CategoryCreatedEvent(BlogId, Id, Title));
		}

        public static Category CreateNew(Guid blogId, string title)
        {
            return new Category(blogId, title);
        }

        public void ChangeTitle(string title)
        {
            Title = title;

            MarkOld();

			Events.Add(new CategoryTitleChangedEvent(Id, Title));
		}
    }
}

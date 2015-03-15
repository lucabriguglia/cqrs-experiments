using System;
using Weapsy.Blog.Domain.Category.Events;
using Weapsy.Blog.Domain.Category.Exceptions;

namespace Weapsy.Blog.Domain.Category
{
	public class Category : AggregateRoot
	{
		public Guid BlogId { get; private set; }
		public string Title { get; private set; }
		public bool Deleted { get; private set; }

		public Category()
		{
			Id = Guid.Empty;
			Deleted = false;
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

		public void Delete()
		{
			IsCategoryCreated();

			if (Deleted)
			{
				throw new CategoryAlreadyDeletedException("The Category is already deleted.");
			}

			Deleted = true;

			MarkOld();

			Events.Add(new CategoryDeletedEvent(Id));
		}

		public void Restore()
		{
			IsCategoryCreated();

			if (!Deleted)
			{
				throw new CategoryNotDeletedException("The Category is not deleted and the restore operation can not be executed.");
			}

			Deleted = false;

			MarkOld();

			Events.Add(new CategoryRestoredEvent(Id));
		}

		private void IsCategoryCreated()
		{
			if (Id == Guid.Empty)
			{
				throw new CategoryNotCreatedException("The Category is not created and no opperations can be executed on it.");
			}
		}
	}
}

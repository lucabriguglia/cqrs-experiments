using System;
using Weapsy.Blog.Domain.Blog.Events;
using Weapsy.Blog.Domain.Blog.Exceptions;

namespace Weapsy.Blog.Domain.Blog
{
	public class Blog : AggregateRoot
	{
		public string Title { get; private set; }
		public bool Deleted { get; private set; }

		public Blog()
		{
			Id = Guid.Empty;
			Deleted = false;
		}

		private Blog(string title) : this()
		{
			Title = title;

			Id = Guid.NewGuid();
			MarkNew();

			Events.Add(new BlogCreatedEvent(Id, Title));
		}

		public static Blog CreateNew(string title)
		{
			return new Blog(title);
		}

		public void ChangeTitle(string title)
		{
			IsBlogCreated();

			Title = title;

			MarkOld();

			Events.Add(new BlogTitleChangedEvent(Id, Title));
		}

		public void Delete()
		{
			IsBlogCreated();

			if (Deleted)
			{
				throw new BlogAlreadyDeletedException("The Blog is already deleted.");
			}

			Deleted = true;

			MarkOld();

			Events.Add(new BlogDeletedEvent(Id));
		}

		public void Restore()
		{
			IsBlogCreated();

			if (!Deleted)
			{
				throw new BlogNotDeletedException("The Blog is not deleted and the restore operation can not be executed.");
			}

			Deleted = false;

			MarkOld();

			Events.Add(new BlogRestoredEvent(Id));
		}

		private void IsBlogCreated()
		{
			if (Id == Guid.Empty)
			{
				throw new BlogNotCreatedException("The Blog is not created and no opperations can be executed on it.");
			}
		}
	}
}

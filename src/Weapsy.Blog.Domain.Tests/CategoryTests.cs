using System;
using System.Linq;
using NUnit.Framework;
using Weapsy.Blog.Domain.Category.Events;
using Weapsy.Blog.Domain.Category.Exceptions;

namespace Weapsy.Blog.Domain.Tests
{
    [TestFixture]
    public class CategoryTests
    {
		[Test]
		public void Should_set_properties_and_notify_when_create_new_category()
		{
			Guid blogId = Guid.NewGuid();
			const string title = "My Category";

			var category = Category.Category.CreateNew(blogId, title);

			var @event = category.Events.OfType<CategoryCreatedEvent>().SingleOrDefault();

			Assert.IsFalse(category.Id == Guid.Empty);
			Assert.AreEqual(blogId, category.BlogId);
			Assert.AreEqual(title, category.Title);
			Assert.IsNotNull(@event);
			Assert.AreEqual(category.BlogId, @event.BlogId);
			Assert.AreEqual(category.Id, @event.Id);
			Assert.AreEqual(category.Title, @event.Title);
		}

		[Test]
		public void Should_set_title_and_notify_when_change_category_title()
		{
			var category = Category.Category.CreateNew(Guid.NewGuid(), "My Category");

			const string newTitle = "New title";

			category.ChangeTitle(newTitle);

			var @event = category.Events.OfType<CategoryTitleChangedEvent>().SingleOrDefault();

			Assert.AreEqual(newTitle, category.Title);
			Assert.IsNotNull(@event);
			Assert.AreEqual(category.Id, @event.Id);
			Assert.AreEqual(category.Title, @event.Title);
		}

        [Test]
        public void Should_throw_category_already_deleted_exception_when_delete_deleted_category()
        {
            var category = Category.Category.CreateNew(Guid.NewGuid(), "My category");
            category.GetType().GetProperty("Deleted").SetValue(category, true, null);

            Assert.Throws<CategoryAlreadyDeletedException>(() => category.Delete());
        }

        [Test]
        public void Should_delete_category_and_notify()
        {
            var category = Category.Category.CreateNew(Guid.NewGuid(), "My category");

            category.Delete();

            var @event = category.Events.OfType<CategoryDeletedEvent>().SingleOrDefault();

            Assert.IsTrue(category.Deleted);
            Assert.IsNotNull(@event);
            Assert.AreEqual(category.Id, @event.Id);
        }

        [Test]
        public void Should_throw_category_not_deleted_exception_when_restore_deleted_category()
        {
            var category = Category.Category.CreateNew(Guid.NewGuid(), "My category");

            Assert.Throws<CategoryNotDeletedException>(() => category.Restore());
        }

        [Test]
        public void Should_restore_category_and_notify()
        {
            var category = Category.Category.CreateNew(Guid.NewGuid(), "My category");
            category.GetType().GetProperty("Deleted").SetValue(category, true, null);

            category.Restore();

            var @event = category.Events.OfType<CategoryRestoredEvent>().SingleOrDefault();

            Assert.IsFalse(category.Deleted);
            Assert.IsNotNull(@event);
            Assert.AreEqual(category.Id, @event.Id);
        }
	}
}

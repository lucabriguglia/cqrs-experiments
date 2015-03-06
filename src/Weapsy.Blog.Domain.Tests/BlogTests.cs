using System;
using System.Linq;
using NUnit.Framework;
using Weapsy.Blog.Domain.Blog.Events;
using Weapsy.Blog.Domain.Blog.Exceptions;

namespace Weapsy.Blog.Domain.Tests
{
    [TestFixture]
    public class BlogTests
    {
        [Test]
        public void Should_set_properties_and_notify_when_create_new_blog()
        {
            const string title = "My Blog";

            var blog = Blog.Blog.CreateNew(title);

	        var @event = blog.Events.OfType<BlogCreatedEvent>().SingleOrDefault();

            Assert.IsFalse(blog.Id == Guid.Empty);
            Assert.AreEqual(title, blog.Title);
			Assert.IsNotNull(@event);
			Assert.AreEqual(blog.Id, @event.Id);
			Assert.AreEqual(blog.Title, @event.Title);
		}

		[Test]
		public void Should_set_title_and_notify_when_change_blog_title()
		{
			var blog = Blog.Blog.CreateNew("My Blog");

			const string newTitle = "New title";

			blog.ChangeTitle(newTitle);

			var @event = blog.Events.OfType<BlogTitleChangedEvent>().SingleOrDefault();

			Assert.AreEqual(newTitle, blog.Title);
			Assert.IsNotNull(@event);
			Assert.AreEqual(blog.Id, @event.Id);
			Assert.AreEqual(blog.Title, @event.Title);
		}

        [Test]
        public void Should_throw_blog_already_deleted_exception_when_delete_deleted_blog()
        {
            var blog = Blog.Blog.CreateNew("My Blog");
            blog.GetType().GetProperty("Deleted").SetValue(blog, true, null);

            Assert.Throws<BlogAlreadyDeletedException>(() => blog.Delete());
        }

        [Test]
        public void Should_delete_blog_and_notify()
        {
            var blog = Blog.Blog.CreateNew("My Blog");

            blog.Delete();

            var @event = blog.Events.OfType<BlogDeletedEvent>().SingleOrDefault();

            Assert.IsTrue(blog.Deleted);
            Assert.IsNotNull(@event);
            Assert.AreEqual(blog.Id, @event.Id);
        }

        [Test]
        public void Should_throw_blog_not_deleted_exception_when_restore_deleted_blog()
        {
            var blog = Blog.Blog.CreateNew("My Blog");

            Assert.Throws<BlogNotDeletedException>(() => blog.Restore());
        }

        [Test]
        public void Should_restore_blog_and_notify()
        {
            var blog = Blog.Blog.CreateNew("My Blog");
            blog.GetType().GetProperty("Deleted").SetValue(blog, true, null);

            blog.Restore();

            var @event = blog.Events.OfType<BlogRestoredEvent>().SingleOrDefault();

            Assert.IsFalse(blog.Deleted);
            Assert.IsNotNull(@event);
            Assert.AreEqual(blog.Id, @event.Id);
        }
	}
}

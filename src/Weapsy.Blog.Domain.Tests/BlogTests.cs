using System;
using System.Linq;
using NUnit.Framework;
using Weapsy.Blog.Domain.Blog.Events;

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
	}
}

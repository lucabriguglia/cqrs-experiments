using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Weapsy.Blog.Domain.Posts;
using Weapsy.Blog.Domain.Posts.Events;
using Weapsy.Blog.Domain.Posts.Exceptions;
using Weapsy.Blog.Domain.Tests.Factories;

namespace Weapsy.Blog.Domain.Tests
{
    [TestFixture]
    public class PostTests
    {
        [Test]
        public void Should_set_properties_when_create_new_post()
        {
            var blogId = Guid.NewGuid();
            const string title = "title";
            const string content = "content";
            const bool published = true;
			var categories = new List<Guid> { Guid.NewGuid() };
			var tags = new List<string> { "tag1", "tag2", "tag3" };

			var post = Post.CreateNew(blogId, title, content, published, categories, tags);

			Assert.IsFalse(post.Id == Guid.Empty);
			Assert.AreEqual(blogId, post.BlogId);
            Assert.AreEqual(title, post.Title);
            Assert.AreEqual(content, post.Content);
            Assert.AreEqual(published, post.Published);
			Assert.AreEqual(categories, post.Categories);
			Assert.AreEqual(tags, post.Tags);
			Assert.IsFalse(post.Deleted);
        }

		[Test]
		public void Should_notify_when_post_is_created()
		{
			var post = PostFactory.CreateNewPost();

			var @event = post.Events.OfType<PostCreatedEvent>().SingleOrDefault();

			Assert.IsNotNull(@event);
			Assert.AreEqual(post, @event.Post);
		}

		[Test]
        public void Should_throw_an_invalid_operation_exception_when_publish_a_deleted_post()
        {
	        var post = PostFactory.CreateNewPost();
            post.GetType().GetProperty("Deleted").SetValue(post, true, null);

            Assert.Throws<PostDeletedException>(() => post.Publish());
        }

        [Test]
        public void Should_publish_post_and_notify()
        {
			var post = PostFactory.CreateNewPost(published: false);

			post.Publish();

			var @event = post.Events.OfType<PostPublishedEvent>().SingleOrDefault();

			Assert.IsTrue(post.Published);
			Assert.IsNotNull(@event);
			Assert.AreEqual(post.Id, @event.Id);
		}

        [Test]
        public void Should_unpublish_post_and_notify()
        {
			var post = PostFactory.CreateNewPost();

			post.Unpublish();

			var @event = post.Events.OfType<PostUnpublishedEvent>().SingleOrDefault();

			Assert.IsFalse(post.Published);
			Assert.IsNotNull(@event);
			Assert.AreEqual(post.Id, @event.Id);
        }

        [Test]
        public void Should_delete_post_and_notify()
        {
			var post = PostFactory.CreateNewPost();

			post.Delete();

			var @event = post.Events.OfType<PostDeletedEvent>().SingleOrDefault();

			Assert.IsTrue(post.Deleted);
            Assert.IsFalse(post.Published);
			Assert.IsNotNull(@event);
			Assert.AreEqual(post.Id, @event.Id);
		}

        [Test]
        public void Should_restore_post_and_notify()
        {
			var post = PostFactory.CreateNewPost();
            post.GetType().GetProperty("Deleted").SetValue(post, true, null);

            post.Restore();

			var @event = post.Events.OfType<PostRestoredEvent>().SingleOrDefault();

			Assert.IsFalse(post.Deleted);
			Assert.IsNotNull(@event);
			Assert.AreEqual(post.Id, @event.Id);
		}
    }
}

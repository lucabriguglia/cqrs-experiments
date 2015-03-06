using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Weapsy.Blog.Domain.Post.Events;
using Weapsy.Blog.Domain.Post.Exceptions;

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

			var post = Post.Post.CreateNew(blogId, title, content, published, categories, tags);

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
		    var post = Post.Post.CreateNew(Guid.NewGuid(), "title", "content", true, new List<Guid>(), new List<string>());

			var @event = post.Events.OfType<PostCreatedEvent>().SingleOrDefault();

			Assert.IsNotNull(@event);
			Assert.AreEqual(post, @event.Post);
		}

		[Test]
        public void Should_throw_post_deleted_exception_when_publish_deleted_post()
        {
            var post = Post.Post.CreateNew(Guid.NewGuid(), "title", "content", false, new List<Guid>(), new List<string>());
            post.GetType().GetProperty("Deleted").SetValue(post, true, null);

            Assert.Throws<PostDeletedException>(() => post.Publish());
        }

        [Test]
        public void Should_publish_post_and_notify()
        {
            var post = Post.Post.CreateNew(Guid.NewGuid(), "title", "content", false, new List<Guid>(), new List<string>());

			post.Publish();

			var @event = post.Events.OfType<PostPublishedEvent>().SingleOrDefault();

			Assert.IsTrue(post.Published);
			Assert.IsNotNull(@event);
			Assert.AreEqual(post.Id, @event.Id);
		}

        [Test]
        public void Should_throw_post_not_published_exception_when_unpublish_an_unblished_post()
        {
            var post = Post.Post.CreateNew(Guid.NewGuid(), "title", "content", false, new List<Guid>(), new List<string>());

            Assert.Throws<PostNotPublishedException>(() => post.Unpublish());
        }

        [Test]
        public void Should_unpublish_post_and_notify()
        {
            var post = Post.Post.CreateNew(Guid.NewGuid(), "title", "content", true, new List<Guid>(), new List<string>());

			post.Unpublish();

			var @event = post.Events.OfType<PostUnpublishedEvent>().SingleOrDefault();

			Assert.IsFalse(post.Published);
			Assert.IsNotNull(@event);
			Assert.AreEqual(post.Id, @event.Id);
        }

        [Test]
        public void Should_throw_post_already_deleted_exception_when_delete_deleted_post()
        {
            var post = Post.Post.CreateNew(Guid.NewGuid(), "title", "content", true, new List<Guid>(), new List<string>());
            post.GetType().GetProperty("Deleted").SetValue(post, true, null);

            Assert.Throws<PostAlreadyDeletedException>(() => post.Delete());
        }

        [Test]
        public void Should_delete_post_and_notify()
        {
            var post = Post.Post.CreateNew(Guid.NewGuid(), "title", "content", true, new List<Guid>(), new List<string>());

			post.Delete();

			var @event = post.Events.OfType<PostDeletedEvent>().SingleOrDefault();

			Assert.IsTrue(post.Deleted);
            Assert.IsFalse(post.Published);
			Assert.IsNotNull(@event);
			Assert.AreEqual(post.Id, @event.Id);
		}

        [Test]
        public void Should_throw_post_not_deleted_exception_when_restore_deleted_post()
        {
            var post = Post.Post.CreateNew(Guid.NewGuid(), "title", "content", true, new List<Guid>(), new List<string>());

            Assert.Throws<PostNotDeletedException>(() => post.Restore());
        }

        [Test]
        public void Should_restore_post_and_notify()
        {
            var post = Post.Post.CreateNew(Guid.NewGuid(), "title", "content", true, new List<Guid>(), new List<string>());
            post.GetType().GetProperty("Deleted").SetValue(post, true, null);

            post.Restore();

			var @event = post.Events.OfType<PostRestoredEvent>().SingleOrDefault();

			Assert.IsFalse(post.Deleted);
			Assert.IsNotNull(@event);
			Assert.AreEqual(post.Id, @event.Id);
		}
    }
}

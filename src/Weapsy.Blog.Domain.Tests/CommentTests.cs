using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Weapsy.Blog.Domain.Comment.Events;
using Weapsy.Blog.Domain.Comment.Exceptions;

namespace Weapsy.Blog.Domain.Tests
{
    [TestFixture]
    public class CommentTests
    {
		[Test]
		public void Should_set_properties_and_notify_when_create_new_comment()
		{
			Guid postId = Guid.NewGuid();
			const string text = "My Comment";

			var comment = Comment.Comment.CreateNew(postId, text, true);

			var @event = comment.Events.OfType<CommentCreatedEvent>().SingleOrDefault();

			Assert.IsFalse(comment.Id == Guid.Empty);
			Assert.AreEqual(postId, comment.PostId);
			Assert.AreEqual(text, comment.Text);
			Assert.IsNotNull(@event);
            Assert.AreEqual(comment.PostId, @event.PostId);
            Assert.AreEqual(comment.Text, @event.Text);
		}

        [Test]
        public void Should_throw_comment_deleted_exception_when_approve_deleted_comment()
        {
            var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My Comment", true);
            comment.GetType().GetProperty("Deleted").SetValue(comment, true, null);

            Assert.Throws<CommentDeletedException>(() => comment.Approve());
        }

        [Test]
        public void Should_throw_comment_already_approved_exception_when_approve_already_approved_comment()
        {
            var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My Comment", true);

            Assert.Throws<CommentAlreadyApprovedException>(() => comment.Approve());
        }

        [Test]
        public void Should_approve_comment_and_notify()
        {
            var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My Comment", false);

            comment.Approve();

            var @event = comment.Events.OfType<CommentApprovedEvent>().SingleOrDefault();

            Assert.IsTrue(comment.Approved);
            Assert.IsNotNull(@event);
            Assert.AreEqual(comment.Id, @event.Id);
        }

        [Test]
        public void Should_throw_comment_deleted_exception_when_disapprove_deleted_comment()
        {
            var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My Comment", true);
            comment.GetType().GetProperty("Deleted").SetValue(comment, true, null);

            Assert.Throws<CommentDeletedException>(() => comment.Disapprove());
        }

        [Test]
        public void Should_throw_comment_not_approved_exception_when_disapprove_not_approved_comment()
        {
            var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My Comment", false);

            Assert.Throws<CommentNotApprovedException>(() => comment.Disapprove());
        }

        [Test]
        public void Should_disapprove_comment_and_notify()
        {
            var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My Comment", true);

            comment.Disapprove();

            var @event = comment.Events.OfType<CommentDisapprovedEvent>().SingleOrDefault();

            Assert.IsFalse(comment.Approved);
            Assert.IsNotNull(@event);
            Assert.AreEqual(comment.Id, @event.Id);
        }

		[Test]
		public void Should_set_title_and_notify_when_change_comment_text()
		{
			var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My Comment", true);

			const string newText = "New Text";

            comment.ChangeText(newText);

			var @event = comment.Events.OfType<CommentTextChangedEvent>().SingleOrDefault();

            Assert.AreEqual(newText, comment.Text);
			Assert.IsNotNull(@event);
			Assert.AreEqual(comment.Id, @event.Id);
            Assert.AreEqual(comment.Text, @event.Text);
		}

        [Test]
        public void Should_throw_comment_already_deleted_exception_when_delete_deleted_comment()
        {
            var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My comment", true);
            comment.GetType().GetProperty("Deleted").SetValue(comment, true, null);

            Assert.Throws<CommentAlreadyDeletedException>(() => comment.Delete());
        }

        [Test]
        public void Should_delete_comment_and_notify()
        {
            var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My comment", true);

            comment.Delete();

            var @event = comment.Events.OfType<CommentDeletedEvent>().SingleOrDefault();

            Assert.IsTrue(comment.Deleted);
            Assert.IsNotNull(@event);
            Assert.AreEqual(comment.Id, @event.Id);
        }

        [Test]
        public void Should_throw_comment_not_deleted_exception_when_restore_not_deleted_comment()
        {
            var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My comment", true);

            Assert.Throws<CommentNotDeletedException>(() => comment.Restore());
        }

        [Test]
        public void Should_restore_comment_and_notify()
        {
            var comment = Comment.Comment.CreateNew(Guid.NewGuid(), "My comment", true);
            comment.GetType().GetProperty("Deleted").SetValue(comment, true, null);

            comment.Restore();

            var @event = comment.Events.OfType<CommentRestoredEvent>().SingleOrDefault();

            Assert.IsFalse(comment.Deleted);
            Assert.IsNotNull(@event);
            Assert.AreEqual(comment.Id, @event.Id);
        }
	}
}

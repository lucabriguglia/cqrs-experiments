using System;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Handlers;
using Weapsy.Blog.Domain.Comment;

namespace Weapsy.Blog.Commands.Tests.Handlers
{
	[TestFixture]
    public class DeleteCommentCommandHandlerTests
    {
		[Test]
		public void Should_call_save_method_when_delete_comment()
		{
			var commentId = Guid.NewGuid();

			var comment = Comment.CreateNew(Guid.NewGuid(), "Text", false);
			comment.GetType().GetProperty("Id").SetValue(comment, commentId, null);

			var commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.GetById(commentId)).Returns(comment);
			commentRepository.Setup(x => x.Save(comment));

			var deleteCommentCommandHandler = new DeleteCommentCommandHandler(commentRepository.Object);
			deleteCommentCommandHandler.Handle(new DeleteCommentCommand(commentId));

			commentRepository.Verify(x => x.Save(comment));
        }
	}
}

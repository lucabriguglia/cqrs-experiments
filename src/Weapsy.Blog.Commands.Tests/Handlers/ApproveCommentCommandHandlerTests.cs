using System;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Handlers;
using Weapsy.Blog.Domain.Comment;

namespace Weapsy.Blog.Commands.Tests.Handlers
{
	[TestFixture]
    public class ApproveCommentCommandHandlerTests
    {
		[Test]
		public void Should_call_save_method_when_approve_comment()
		{
			var commentId = Guid.NewGuid();

			var comment = Comment.CreateNew(Guid.NewGuid(), "Text", false);
			comment.GetType().GetProperty("Id").SetValue(comment, commentId, null);

			var commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.GetById(commentId)).Returns(comment);
			commentRepository.Setup(x => x.Save(comment));

			var approveCommentCommandHandler = new ApproveCommentCommandHandler(commentRepository.Object);
			approveCommentCommandHandler.Handle(new ApproveCommentCommand(commentId));

			commentRepository.Verify(x => x.Save(comment));
        }
	}
}

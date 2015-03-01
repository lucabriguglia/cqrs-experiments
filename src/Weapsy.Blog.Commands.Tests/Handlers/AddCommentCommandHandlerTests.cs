using System;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Handlers;
using Weapsy.Blog.Domain.Comment;

namespace Weapsy.Blog.Commands.Tests.Handlers
{
	[TestFixture]
    public class AddCommentCommandHandlerTests
    {
		[Test]
		public void Should_call_validate_command_when_add_new_comment()
		{
			var comment = Comment.CreateNew(Guid.NewGuid(), "Text", false);
            var command = new AddCommentCommand(comment.PostId, comment.Text, comment.Approved);

            var commentRepository = new Mock<ICommentRepository>();

            var validator = new Mock<IValidator<AddCommentCommand>>();
            validator.Setup(x => x.Validate(command)).Returns(new ValidationResult());

			var addCommentCommandHandler = new AddCommentCommandHandler(commentRepository.Object, validator.Object);
			addCommentCommandHandler.Handle(command);

            validator.Verify(x => x.Validate(command));
        }
    }
}

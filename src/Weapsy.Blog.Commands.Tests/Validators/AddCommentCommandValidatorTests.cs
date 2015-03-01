using System;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Validators;
using Weapsy.Blog.Domain.Posts;

namespace Weapsy.Blog.Commands.Tests.Validators
{
	[TestFixture]
    public class AddCommentCommandValidatorTests
    {
		[Test]
		public void Should_have_error_when_comment_text_is_empty()
		{
			var postRepository = new Mock<IPostRepository>();
			var validator = new AddCommentCommandValidator(postRepository.Object);
			var command = new AddCommentCommand(Guid.NewGuid(), "", false);

			validator.ShouldHaveValidationErrorFor(x => x.Text, command);
		}

		[Test]
		public void Should_have_error_when_post_does_not_exist()
		{
		    var postId = Guid.NewGuid();

            var postRepository = new Mock<IPostRepository>();
            postRepository.Setup(x => x.GetById(postId)).Returns<Post>(null);

            var validator = new AddCommentCommandValidator(postRepository.Object);
            var command = new AddCommentCommand(postId, "", false);

			validator.ShouldHaveValidationErrorFor(x => x.PostId, command);
		}
	}
}

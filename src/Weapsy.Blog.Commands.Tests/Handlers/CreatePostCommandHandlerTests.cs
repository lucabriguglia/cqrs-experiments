using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Handlers;
using Weapsy.Blog.Domain.Post;

namespace Weapsy.Blog.Commands.Tests.Handlers
{
	[TestFixture]
    public class CreatePostCommandHandlerTests
    {
		[Test]
		public void Should_call_validate_command_when_create_new_post()
		{
			var post = Post.CreateNew(Guid.NewGuid(), "Title", "Content", false, new List<Guid>(), new List<string>());
			var command = new CreatePostCommand(post.BlogId, post.Title, post.Content, post.Published, post.Categories, post.Tags);

            var postRepository = new Mock<IPostRepository>();

            var validator = new Mock<IValidator<CreatePostCommand>>();
            validator.Setup(x => x.Validate(command)).Returns(new ValidationResult());

			var createPostCommandHandler = new CreatePostCommandHandler(postRepository.Object, validator.Object);
			createPostCommandHandler.Handle(command);

            validator.Verify(x => x.Validate(command));
        }
    }
}

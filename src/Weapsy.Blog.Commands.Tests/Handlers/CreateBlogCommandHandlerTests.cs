using FluentValidation;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Handlers;
using Weapsy.Blog.Domain.Blog;

namespace Weapsy.Blog.Commands.Tests.Handlers
{
	[TestFixture]
    public class CreateBlogCommandHandlerTests
    {
		[Test]
		public void Should_call_validate_command_when_create_new_blog()
		{
			var blog = Domain.Blog.Blog.CreateNew("Title");
			var command = new CreateBlogCommand(blog.Title);

            var blogRepository = new Mock<IBlogRepository>();

            var validator = new Mock<IValidator<CreateBlogCommand>>();
            validator.Setup(x => x.Validate(command)).Returns(new ValidationResult());

			var createBlogCommandHandler = new CreateBlogCommandHandler(blogRepository.Object, validator.Object);
			createBlogCommandHandler.Handle(command);

            validator.Verify(x => x.Validate(command));
        }
    }
}

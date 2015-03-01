using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Validators;
using Weapsy.Blog.Domain.Blog;

namespace Weapsy.Blog.Commands.Tests.Validators
{
	[TestFixture]
    public class CreateBlogCommandValidatorTests
    {
		[Test]
		public void Should_have_error_when_blog_title_is_empty()
		{
			const string blogTitle = "My Blog";

			var blogRepository = new Mock<IBlogRepository>();
			blogRepository.Setup(x => x.GetByTitle(blogTitle)).Returns(Domain.Blog.Blog.CreateNew(blogTitle));

			var validator = new CreateBlogCommandValidator(blogRepository.Object);

			validator.ShouldHaveValidationErrorFor(x => x.Title, new CreateBlogCommand(""));
		}

		[Test]
		public void Should_have_error_when_blog_title_already_exists()
		{
			const string blogTitle = "My Blog";

			var blogRepository = new Mock<IBlogRepository>();
			blogRepository.Setup(x => x.GetByTitle(blogTitle)).Returns(Domain.Blog.Blog.CreateNew(blogTitle));

			var validator = new CreateBlogCommandValidator(blogRepository.Object);

			validator.ShouldHaveValidationErrorFor(x => x.Title, new CreateBlogCommand(blogTitle));
		}
	}
}

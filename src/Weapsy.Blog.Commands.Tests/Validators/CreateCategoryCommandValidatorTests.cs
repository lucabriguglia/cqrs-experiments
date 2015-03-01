using System;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Validators;
using Weapsy.Blog.Domain.Category;

namespace Weapsy.Blog.Commands.Tests.Validators
{
	[TestFixture]
    public class CreateCategoryCommandValidatorTests
    {
		[Test]
		public void Should_have_error_when_category_title_is_empty()
		{
			var categoryRepository = new Mock<ICategoryRepository>();

			var validator = new CreateCategoryCommandValidator(categoryRepository.Object);

			validator.ShouldHaveValidationErrorFor(x => x.Title, new CreateCategoryCommand(Guid.NewGuid(), ""));
		}

		[Test]
		public void Should_have_error_when_category_title_already_exists()
		{
			var blogId = Guid.NewGuid();
			const string categoryTitle = "My Category";

			var categoryRepository = new Mock<ICategoryRepository>();
			categoryRepository.Setup(x => x.GetByBlogIdAndTitle(blogId, categoryTitle)).Returns(Category.CreateNew(blogId, categoryTitle));

			var validator = new CreateCategoryCommandValidator(categoryRepository.Object);

			validator.ShouldHaveValidationErrorFor(x => x.Title, new CreateCategoryCommand(blogId, categoryTitle));
		}
	}
}

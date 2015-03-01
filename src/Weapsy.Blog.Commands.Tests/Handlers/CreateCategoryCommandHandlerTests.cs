using System;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Handlers;
using Weapsy.Blog.Domain.Category;

namespace Weapsy.Blog.Commands.Tests.Handlers
{
	[TestFixture]
    public class CreateCategoryCommandHandlerTests
    {
		[Test]
		public void Should_call_validate_command_when_create_new_category()
		{
			var category = Category.CreateNew(Guid.NewGuid(), "Title");
			var command = new CreateCategoryCommand(category.BlogId, category.Title);

            var categoryRepository = new Mock<ICategoryRepository>();

            var validator = new Mock<IValidator<CreateCategoryCommand>>();
            validator.Setup(x => x.Validate(command)).Returns(new ValidationResult());

			var createCategoryCommandHandler = new CreateCategoryCommandHandler(categoryRepository.Object, validator.Object);
			createCategoryCommandHandler.Handle(command);

            validator.Verify(x => x.Validate(command));
        }
    }
}

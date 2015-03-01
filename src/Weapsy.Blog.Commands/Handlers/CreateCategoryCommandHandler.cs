using System;
using FluentValidation;
using Weapsy.Blog.Commands.Handlers.Contracts;
using Weapsy.Blog.Commands.Validators;
using Weapsy.Blog.Domain.Category;

namespace Weapsy.Blog.Commands.Handlers
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
		private readonly IValidator<CreateCategoryCommand> _validator;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IValidator<CreateCategoryCommand> validator)
        {
            _categoryRepository = categoryRepository;
			_validator = validator;
        }

        public void Handle(CreateCategoryCommand command)
        {
            var result = _validator.Validate(command);

            if (!result.IsValid)
            {
                var failures = result.Errors;
                throw new InvalidOperationException();
            }

			_categoryRepository.Save(Category.CreateNew(command.BlogId, command.Title));
        }
    }
}

using FluentValidation;
using FluentValidation.Results;
using Weapsy.Blog.Domain.Category;

namespace Weapsy.Blog.Commands.Validators
{
	public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
	{
		private readonly ICategoryRepository _categoryRepository;

		public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;

			RuleFor(c => c.Title).NotEmpty();

			Custom(c =>
			{
				var blog = _categoryRepository.GetByBlogIdAndTitle(c.BlogId, c.Title);

				return blog != null
					? new ValidationFailure("Title", "A category with the same title already exists.") { CustomState = "CustomState" }
					: null;
			});
		}
	}
}

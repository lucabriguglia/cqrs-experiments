using FluentValidation;
using FluentValidation.Results;
using Weapsy.Blog.Domain.Blog;

namespace Weapsy.Blog.Commands.Validators
{
	public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
	{
		private readonly IBlogRepository _blogRepository;

		public CreateBlogCommandValidator(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;

			RuleFor(c => c.Title).NotEmpty();

			Custom(c =>
			{
				var blog = _blogRepository.GetByTitle(c.Title);

				return blog != null
					? new ValidationFailure("Title", "A blog with the same title already exists.") { CustomState = "CustomState" }
					: null;
			});
		}
	}
}

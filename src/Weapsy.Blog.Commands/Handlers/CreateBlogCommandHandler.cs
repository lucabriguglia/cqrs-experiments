using System;
using FluentValidation;
using Weapsy.Blog.Commands.Handlers.Contracts;
using Weapsy.Blog.Commands.Validators;
using Weapsy.Blog.Domain.Blog;

namespace Weapsy.Blog.Commands.Handlers
{
	public class CreateBlogCommandHandler : ICommandHandler<CreateBlogCommand>
	{
		private readonly IBlogRepository _blogRepository;
		private readonly IValidator<CreateBlogCommand> _validator;

		public CreateBlogCommandHandler(IBlogRepository blogRepository, IValidator<CreateBlogCommand> validator)
		{
			_blogRepository = blogRepository;
			_validator = validator;
		}

		public void Handle(CreateBlogCommand command)
		{
			var validationResult = _validator.Validate(command);

			if (!validationResult.IsValid)
			{
				var failures = validationResult.Errors;
				throw new InvalidOperationException();
			}

			_blogRepository.Save(Domain.Blog.Blog.CreateNew(command.Title));
		}
	}
}

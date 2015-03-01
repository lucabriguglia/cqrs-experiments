using FluentValidation;
using FluentValidation.Results;
using Weapsy.Blog.Domain.Posts;

namespace Weapsy.Blog.Commands.Validators
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        private readonly IPostRepository _postRepository;

        public AddCommentCommandValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;

            RuleFor(c => c.Text).NotEmpty();

			Custom(c =>
			{
                var post = _postRepository.GetById(c.PostId);

				return post == null
					? new ValidationFailure("PostId", "Requested post doesn't exist.") {CustomState = "CustomState"}
					: null;
			});
        }
    }
}

using FluentValidation;
using FluentValidation.Results;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Blog;
using Weapsy.Blog.Domain.Post;

namespace Weapsy.Blog.Commands.Validators
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IPostRepository _postRepository;

        public CreatePostCommandValidator(IBlogRepository blogRepository, IPostRepository postRepository)
        {
            _blogRepository = blogRepository;
            _postRepository = postRepository;

            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Content).NotEmpty();

			Custom(c =>
			{
				var blog = _blogRepository.GetById(c.BlogId);

				return blog == null
					? new ValidationFailure("BlogId", "Requested blog doesn't exist.") {CustomState = "CustomState"}
					: null;
			});

			Custom(c =>
            {
                var existingPost = _postRepository.GetByBlogIdAndTitle(c.BlogId, c.Title);

                return existingPost != null
					? new ValidationFailure("Title", "A post with the same title already exists.") {CustomState = "CustomState"} 
					: null;
            });
        }
    }
}

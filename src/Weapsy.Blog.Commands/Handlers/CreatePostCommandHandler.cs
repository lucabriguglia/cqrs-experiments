using System;
using FluentValidation;
using Weapsy.Blog.Commands.Handlers.Contracts;
using Weapsy.Blog.Domain.Posts;

namespace Weapsy.Blog.Commands.Handlers
{
    public class CreatePostCommandHandler : ICommandHandler<CreatePostCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly IValidator<CreatePostCommand> _validator;

        public CreatePostCommandHandler(IPostRepository postRepository, IValidator<CreatePostCommand> validator)
        {
            _postRepository = postRepository;
	        _validator = validator;
        }

        public void Handle(CreatePostCommand command)
        {
            var result = _validator.Validate(command);

            if (!result.IsValid)
            {
                var failures = result.Errors;
                throw new InvalidOperationException();
            }

            var post = Post.CreateNew(command.BlogId, command.Title, command.Content, command.Published, command.Categories, command.Tags);
            
            _postRepository.Save(post);
		}
    }
}

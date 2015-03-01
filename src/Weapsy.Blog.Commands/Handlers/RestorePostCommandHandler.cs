using Weapsy.Blog.Commands.Handlers.Contracts;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Posts;

namespace Weapsy.Blog.Commands.Handlers
{
    public class RestorePostCommandHandler : ICommandHandler<RestorePostCommand>
    {
        private readonly IRepository<Post> _postRepository;

        public RestorePostCommandHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public void Handle(RestorePostCommand command)
        {
            var post = _postRepository.GetById(command.Id);

            post.Restore();

            _postRepository.Save(post);
        }
    }
}

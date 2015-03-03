using Weapsy.Blog.Commands.Handlers.Contracts;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Post;

namespace Weapsy.Blog.Commands.Handlers
{
    public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
    {
        private readonly IRepository<Post> _postRepository;

        public DeletePostCommandHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public void Handle(DeletePostCommand command)
        {
            var post = _postRepository.GetById(command.Id);

            post.Delete();

            _postRepository.Save(post);
        }
    }
}

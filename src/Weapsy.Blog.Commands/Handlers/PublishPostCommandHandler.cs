using Weapsy.Blog.Commands.Handlers.Contracts;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Post;

namespace Weapsy.Blog.Commands.Handlers
{
	public class PublishPostCommandHandler : ICommandHandler<PublishPostCommand>
	{
		private readonly IRepository<Post> _postRepository;

		public PublishPostCommandHandler(IRepository<Post> postRepository)
		{
			_postRepository = postRepository;
		}

		public void Handle(PublishPostCommand command)
		{
			var post = _postRepository.GetById(command.Id);

			post.Publish();

			_postRepository.Save(post);
		}
	}
}

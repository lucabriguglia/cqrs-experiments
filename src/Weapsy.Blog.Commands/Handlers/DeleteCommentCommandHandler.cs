using Weapsy.Blog.Commands.Handlers.Contracts;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Comment;

namespace Weapsy.Blog.Commands.Handlers
{
	public class DeleteCommentCommandHandler : ICommandHandler<DeleteCommentCommand>
	{
		private readonly IRepository<Comment> _commentRepository;

		public DeleteCommentCommandHandler(IRepository<Comment> commentRepository)
		{
			_commentRepository = commentRepository;
		}

		public void Handle(DeleteCommentCommand command)
		{
			var post = _commentRepository.GetById(command.Id);

			post.Delete();

			_commentRepository.Save(post);
		}
	}
}

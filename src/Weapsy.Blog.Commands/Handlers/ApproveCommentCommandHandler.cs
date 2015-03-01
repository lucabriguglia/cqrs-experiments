using Weapsy.Blog.Commands.Handlers.Contracts;
using Weapsy.Blog.Domain.Comment;

namespace Weapsy.Blog.Commands.Handlers
{
    public class ApproveCommentCommandHandler : ICommandHandler<ApproveCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

		public ApproveCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Handle(ApproveCommentCommand command)
        {
            var comment = _commentRepository.GetById(command.Id);

			comment.Approve();

            _commentRepository.Save(comment);
        }
    }
}

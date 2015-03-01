using System;
using FluentValidation;
using Weapsy.Blog.Commands.Handlers.Contracts;
using Weapsy.Blog.Domain.Comment;

namespace Weapsy.Blog.Commands.Handlers
{
    public class AddCommentCommandHandler : ICommandHandler<AddCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IValidator<AddCommentCommand> _validator;

        public AddCommentCommandHandler(ICommentRepository commentRepository, IValidator<AddCommentCommand> validator)
        {
            _commentRepository = commentRepository;
            _validator = validator;
        }

        public void Handle(AddCommentCommand command)
        {
            var result = _validator.Validate(command);

            if (!result.IsValid)
            {
                var failures = result.Errors;
                throw new InvalidOperationException();
            }

            var comment = Comment.CreateNew(command.PostId, command.Text, command.Approved);

            _commentRepository.Save(comment);
        }
    }
}

using System;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Commands
{
    public class DeleteCommentCommand : ICommand
    {
        public Guid Id { get; private set; }

        public DeleteCommentCommand(Guid id)
        {
            Id = id;
        }
    }
}

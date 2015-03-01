using System;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Commands
{
    public class RestorePostCommand : ICommand
    {
        public Guid Id { get; private set; }

        public RestorePostCommand(Guid id)
        {
            Id = id;
        }
    }
}

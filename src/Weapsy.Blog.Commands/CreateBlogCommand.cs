using System;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Commands
{
    public class CreateBlogCommand : ICommand
    {
        public string Title { get; private set; }

        public CreateBlogCommand(string title)
        {
            Title = title;
        }
    }
}

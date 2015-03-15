using System;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Commands
{
	public class CreateCategoryCommand : ICommand
	{
		public Guid BlogId { get; private set; }
		public string Title { get; private set; }

		public CreateCategoryCommand(Guid blogId, string title)
		{
			BlogId = blogId;
			Title = title;
		}
	}
}

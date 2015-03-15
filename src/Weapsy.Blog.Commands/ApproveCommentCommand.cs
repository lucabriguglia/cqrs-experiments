using System;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Commands
{
	public class ApproveCommentCommand : ICommand
	{
		public Guid Id { get; private set; }

		public ApproveCommentCommand(Guid id)
		{
			Id = id;
		}
	}
}

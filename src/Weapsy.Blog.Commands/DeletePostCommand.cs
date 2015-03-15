using System;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Commands
{
	public class DeletePostCommand : ICommand
	{
		public Guid Id { get; private set; }

		public DeletePostCommand(Guid id)
		{
			Id = id;
		}
	}
}

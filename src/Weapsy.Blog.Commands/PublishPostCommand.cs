using System;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Commands
{
	public class PublishPostCommand : ICommand
	{
		public Guid Id { get; private set; }

		public PublishPostCommand(Guid id)
		{
			Id = id;
		}
	}
}

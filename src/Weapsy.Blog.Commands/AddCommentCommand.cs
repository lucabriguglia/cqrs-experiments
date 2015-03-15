using System;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Commands
{
	public class AddCommentCommand : ICommand
	{
		public Guid PostId { get; private set; }
		public string Text { get; private set; }
		public bool Approved { get; private set; }

		public AddCommentCommand(Guid postId, string text, bool approved)
		{
			PostId = postId;
			Text = text;
			Approved = approved;
		}
	}
}

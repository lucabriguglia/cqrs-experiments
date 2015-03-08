using System;
using System.Threading.Tasks;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Comment.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class CommentApprovedEventHandler : IEventHandler<CommentApprovedEvent>
	{
		public Task Execute(CommentApprovedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
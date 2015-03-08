using System;
using System.Threading.Tasks;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Comment.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class CommentCreatedEventHandler : IEventHandler<CommentCreatedEvent>
	{
		public Task Execute(CommentCreatedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
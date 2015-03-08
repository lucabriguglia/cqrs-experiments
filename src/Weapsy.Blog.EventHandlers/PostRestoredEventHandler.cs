using System;
using System.Threading.Tasks;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Post.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class PostRestoredEventHandler : IEventHandler<PostRestoredEvent>
	{
		public Task Execute(PostRestoredEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
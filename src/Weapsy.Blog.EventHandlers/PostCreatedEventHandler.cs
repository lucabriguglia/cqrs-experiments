using System;
using System.Threading.Tasks;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Post.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class PostCreatedEventHandler : IEventHandler<PostCreatedEvent>
	{
		public Task Execute(PostCreatedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
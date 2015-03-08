using System;
using System.Threading.Tasks;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Post.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class PostDeletedEventHandler : IEventHandler<PostDeletedEvent>
	{
		public Task Execute(PostDeletedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
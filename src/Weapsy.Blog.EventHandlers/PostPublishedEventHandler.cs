using System;
using System.Threading.Tasks;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Post.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class PostPublishedEventHandler : IEventHandler<PostPublishedEvent>
	{
		public Task Execute(PostPublishedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
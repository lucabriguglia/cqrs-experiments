using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Handlers;
using Weapsy.Blog.Domain.Posts;

namespace Weapsy.Blog.Commands.Tests.Handlers
{
	[TestFixture]
    public class PublishPostCommandHandlerTests
    {
		[Test]
		public void Should_call_save_method_when_publish_post()
		{
			var postId = Guid.NewGuid();

			var post = Post.CreateNew(Guid.NewGuid(), "Title", "Content", false, new List<Guid>(), new List<string>());
			post.GetType().GetProperty("Id").SetValue(post, postId, null);

			var postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.GetById(postId)).Returns(post);
			postRepository.Setup(x => x.Save(post));

			var publishPostCommandHandler = new PublishPostCommandHandler(postRepository.Object);
			publishPostCommandHandler.Handle(new PublishPostCommand(postId));

			postRepository.Verify(x => x.Save(post));
        }
	}
}

using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Handlers;
using Weapsy.Blog.Domain.Post;

namespace Weapsy.Blog.Commands.Tests.Handlers
{
	[TestFixture]
    public class DeletePostCommandHandlerTests
    {
		[Test]
		public void Should_call_save_method_when_delete_post()
		{
			var postId = Guid.NewGuid();

			var post = Post.CreateNew(Guid.NewGuid(), "Title", "Content", true, new List<Guid>(), new List<string>());
			post.GetType().GetProperty("Id").SetValue(post, postId, null);

			var postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.GetById(postId)).Returns(post);
			postRepository.Setup(x => x.Save(post));

			var deletePostCommandHandler = new DeletePostCommandHandler(postRepository.Object);
			deletePostCommandHandler.Handle(new DeletePostCommand(postId));

			postRepository.Verify(x => x.Save(post));
        }
	}
}

using System;
using System.Collections.Generic;
using System.Reflection;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Handlers;
using Weapsy.Blog.Domain.Post;

namespace Weapsy.Blog.Commands.Tests.Handlers
{
	[TestFixture]
    public class RestorePostCommandHandlerTests
    {
		[Test]
		public void Should_call_save_method_when_restore_post()
		{
			var postId = Guid.NewGuid();

			var post = Post.CreateNew(Guid.NewGuid(), "Title", "Content", false, new List<Guid>(), new List<string>());
			post.GetType().GetProperty("Id").SetValue(post, postId, null);
			post.GetType().GetProperty("Deleted").SetValue(post, true, null);

			var postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.GetById(postId)).Returns(post);
			postRepository.Setup(x => x.Save(post));

			var restorePostCommandHandler = new RestorePostCommandHandler(postRepository.Object);
			restorePostCommandHandler.Handle(new RestorePostCommand(postId));

			postRepository.Verify(x => x.Save(post));
        }
	}
}

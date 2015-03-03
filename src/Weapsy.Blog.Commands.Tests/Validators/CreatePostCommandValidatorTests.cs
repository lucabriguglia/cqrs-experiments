using System;
using System.Collections.Generic;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Weapsy.Blog.Commands.Validators;
using Weapsy.Blog.Domain.Blog;
using Weapsy.Blog.Domain.Post;

namespace Weapsy.Blog.Commands.Tests.Validators
{
	[TestFixture]
    public class CreatePostCommandValidatorTests
    {
		[Test]
		public void Should_have_error_when_post_title_is_empty()
		{
			var blogRepository = new Mock<IBlogRepository>();
			var postRepository = new Mock<IPostRepository>();
			var validator = new CreatePostCommandValidator(blogRepository.Object, postRepository.Object);
			var command = new CreatePostCommand(Guid.NewGuid(), "", "content", true, new List<Guid>(), new List<string>());

			validator.ShouldHaveValidationErrorFor(x => x.Title, command);
		}

		[Test]
		public void Should_have_error_when_post_content_is_empty()
		{
			var blogRepository = new Mock<IBlogRepository>();
			var postRepository = new Mock<IPostRepository>();
			var validator = new CreatePostCommandValidator(blogRepository.Object, postRepository.Object);
			var command = new CreatePostCommand(Guid.NewGuid(), "title", "", true, new List<Guid>(), new List<string>());

			validator.ShouldHaveValidationErrorFor(x => x.Content, command);
		}

		[Test]
		public void Should_have_error_when_blog_does_not_exist()
		{
		    var blogId = Guid.NewGuid();

            var blogRepository = new Mock<IBlogRepository>();
            blogRepository.Setup(x => x.GetById(blogId)).Returns<Domain.Blog.Blog>(null);

			var postRepository = new Mock<IPostRepository>();
			var validator = new CreatePostCommandValidator(blogRepository.Object, postRepository.Object);
            var command = new CreatePostCommand(blogId, "title", "content", true, new List<Guid>(), new List<string>());

			validator.ShouldHaveValidationErrorFor(x => x.BlogId, command);
		}

		[Test]
		public void Should_have_error_when_post_title_already_exists()
		{
			var blogId = Guid.NewGuid();
			const string postTitle = "My Post";

			var postRepository = new Mock<IPostRepository>();
			postRepository
				.Setup(x => x.GetByBlogIdAndTitle(blogId, postTitle))
				.Returns(Post.CreateNew(blogId, postTitle, "content", true, new List<Guid>(), new List<string>()));

			var blogRepository = new Mock<IBlogRepository>();
			var validator = new CreatePostCommandValidator(blogRepository.Object, postRepository.Object);
			var command = new CreatePostCommand(blogId, postTitle, "content", true, new List<Guid>(), new List<string>());

			validator.ShouldHaveValidationErrorFor(x => x.Title, command);
		}
	}
}

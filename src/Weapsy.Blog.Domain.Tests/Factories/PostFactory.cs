﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weapsy.Blog.Domain.Posts;

namespace Weapsy.Blog.Domain.Tests.Factories
{
	public static class PostFactory
	{
		public static Post CreateNewPost(bool published = true)
		{
			var categories = new List<Guid> {Guid.NewGuid()};
			var tags = new List<string> {"tag1", "tag2", "tag3"};

			return Post.CreateNew(Guid.NewGuid(), "Title", "Content", published, categories, tags);
		}
	}
}
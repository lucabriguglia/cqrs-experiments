using System;
using System.Collections.Generic;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Commands
{
	public class CreatePostCommand : ICommand
	{
		public Guid BlogId { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public bool Published { get; private set; }
		public List<Guid> Categories { get; private set; }
		public List<string> Tags { get; private set; }

		public CreatePostCommand(Guid blogId, string title, string content, bool published, List<Guid> categories, List<string> tags)
		{
			BlogId = blogId;
			Title = title;
			Content = content;
			Published = published;
			Categories = categories;
			Tags = tags;
		}
	}
}

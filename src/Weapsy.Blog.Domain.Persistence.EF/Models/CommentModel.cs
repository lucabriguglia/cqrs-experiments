using System;

namespace Weapsy.Blog.Domain.Persistence.EF.Models
{
	public class CommentModel : IEntity
	{
		public Guid PostId { get; set; }
		public Guid Id { get; set; }
		public string Text { get; set; }
		public bool Approved { get; set; }
		public bool Deleted { get; set; }

		public virtual PostModel Post { get; set; }
	}
}

using System.Data.Entity.ModelConfiguration;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.ModelConfigurations
{
	public class CommentModelConfiguration : EntityTypeConfiguration<CommentModel>
	{
		public CommentModelConfiguration()
		{
			ToTable("BlogPostComment");

			HasKey(x => x.Id);

			Property(x => x.Text).IsRequired().HasMaxLength(400);
			Property(x => x.Approved).IsRequired();
			Property(x => x.Deleted).IsRequired();

			HasRequired(x => x.Post)
				.WithMany(y => y.Comments)
				.HasForeignKey(x => x.PostId)
				.WillCascadeOnDelete(true);
		}
	}
}
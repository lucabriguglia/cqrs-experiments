using System.Data.Entity.ModelConfiguration;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.ModelConfigurations
{
	public class PostTagModelConfiguration : EntityTypeConfiguration<PostTagModel>
	{
		public PostTagModelConfiguration()
		{
			ToTable("BlogPostTag");

			HasKey(x => new { x.PostId, x.TagName });

			HasRequired(x => x.Post)
				.WithMany(y => y.PostTags)
				.HasForeignKey(x => x.PostId);
		}
	}
}
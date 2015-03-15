using System.Data.Entity.ModelConfiguration;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.ModelConfigurations
{
	public class PostModelConfiguration : EntityTypeConfiguration<PostModel>
	{
		public PostModelConfiguration()
		{
			ToTable("BlogPost");

			HasKey(x => x.Id);

			Property(x => x.Title).IsRequired().HasMaxLength(100);
			Property(x => x.Content).IsRequired().IsMaxLength();
			Property(x => x.Published).IsRequired();
			Property(x => x.Deleted).IsRequired();

			HasRequired(x => x.Blog)
				.WithMany(y => y.Posts)
				.HasForeignKey(x => x.BlogId)
				.WillCascadeOnDelete(true);
		}
	}
}
using System.Data.Entity.ModelConfiguration;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.ModelConfigurations
{
    public class PostCategoryModelConfiguration : EntityTypeConfiguration<PostCategoryModel>
    {
        public PostCategoryModelConfiguration()
        {
            ToTable("BlogPostCategory");

            HasKey(x => new { x.PostId, x.CategoryId });

            HasRequired(x => x.Post)
                .WithMany(y => y.PostCategories)
                .HasForeignKey(x => x.PostId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Category)
                .WithMany(y => y.PostCategories)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
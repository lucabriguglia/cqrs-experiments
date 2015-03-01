using System.Data.Entity.ModelConfiguration;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.ModelConfigurations
{
    public class CategoryModelConfiguration : EntityTypeConfiguration<CategoryModel>
    {
        public CategoryModelConfiguration()
        {
            ToTable("BlogCategory");

            HasKey(x => x.Id);

            Property(x => x.Title).IsRequired().HasMaxLength(100);

            HasRequired(x => x.Blog)
                .WithMany(y => y.Categories)
                .HasForeignKey(x => x.BlogId)
                .WillCascadeOnDelete(true);
        }
    }
}
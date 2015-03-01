using System.Data.Entity.ModelConfiguration;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.ModelConfigurations
{
    public class BlogModelConfiguration : EntityTypeConfiguration<BlogModel>
    {
        public BlogModelConfiguration()
        {
            ToTable("Blog");

            HasKey(a => a.Id);

            Property(a => a.Title).IsRequired().HasMaxLength(100);
        }
    }
}
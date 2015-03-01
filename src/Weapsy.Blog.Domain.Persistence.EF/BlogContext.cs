using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace Weapsy.Blog.Domain.Persistence.EF
{
    public class BlogContext : DbContext, IDbContext
    {
        public BlogContext()
            : base("Data Source=.\\SQLEXPRESS;Initial Catalog=WeapsyBlog4;Integrated Security=SSPI")
        {
        }

        public BlogContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName.ToLowerInvariant().Contains("weapsy")))
            {
                var allTypes = assembly.GetTypes()
                    .Where(t => t.BaseType != null && t.BaseType.IsGenericType).ToArray();

                var configTypes = allTypes.Where(t => t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

                foreach (var type in configTypes)
                {
                    dynamic configurationInstance = Activator.CreateInstance(type);
                    modelBuilder.Configurations.Add(configurationInstance);
                }

                var entityTypes = allTypes.Where(t => t.IsClass && t.GetInterface(typeof(IEntity).FullName) != null);

                foreach (var type in entityTypes)
                {
                    MethodInfo method = modelBuilder.GetType().GetMethod("Entity");
                    method = method.MakeGenericMethod(type);
                    method.Invoke(modelBuilder, null);
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }

        public new DbEntityEntry<T> Entry<T>(T entity) where T : class, IEntity
        {
            return base.Entry<T>(entity);
        }
    }
}

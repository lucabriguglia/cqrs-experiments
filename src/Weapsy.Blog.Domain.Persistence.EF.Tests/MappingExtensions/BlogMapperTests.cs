using System;
using NUnit.Framework;
using Weapsy.Data.MappingExtensions;
using Weapsy.Data.Models;
using Weapsy.Data.Tasks;
using Weapsy.Domain.Blog;

namespace Weapsy.Data.Tests.MappingExtensions
{
    [TestFixture]
    public class BlogMapperTests
    {
        [SetUp]
        public void Setup()
        {
            var autoMapperStartupTask = new AutoMapperStartupTask();
            autoMapperStartupTask.Execute();
        }

        [Test]
        public void Should_map_data_model_properties_to_domain()
        {
            var blogModel = new BlogModel
            {
                Id = Guid.NewGuid(),
                Title = "Blog"
            };

            var blog = blogModel.ToDomain();

            Assert.AreEqual(blogModel.Id, blog.Id);
            Assert.AreEqual(blogModel.Title, blog.Title);
        }

        [Test]
        public void Should_map_domain_properties_to_data_model()
        {
            var blog = new Blog(Guid.NewGuid(), "Blog");

            var blogModel = blog.ToModel();

            Assert.AreEqual(blog.Id, blogModel.Id);
            Assert.AreEqual(blog.Title, blogModel.Title);
        }
    }
}

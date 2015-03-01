using System;
using NUnit.Framework;
using Weapsy.Blog.Domain.Persistence.EF.MappingExtensions;
using Weapsy.Blog.Domain.Persistence.EF.Models;
using Weapsy.Blog.Domain.Persistence.EF.Tasks;

namespace Weapsy.Blog.Domain.Persistence.EF.Tests.MappingExtensions
{
    [TestFixture]
    public class PostMapperTests
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
            var postModel = new PostModel
            {
                Id = Guid.NewGuid(),
                Title = "Title",
                Content = "Content",
                Published = true,
                BlogId = Guid.NewGuid()
            };

            postModel.PostCategories.Add(new PostCategoryModel { PostId = postModel.Id, CategoryId = Guid.NewGuid() });
            postModel.PostCategories.Add(new PostCategoryModel { PostId = postModel.Id, CategoryId = Guid.NewGuid() });
            postModel.PostCategories.Add(new PostCategoryModel { PostId = postModel.Id, CategoryId = Guid.NewGuid() });

            postModel.PostTags.Add(new PostTagModel { PostId = postModel.Id, TagName = "Tag 1" });
            postModel.PostTags.Add(new PostTagModel { PostId = postModel.Id, TagName = "Tag 2" });
            postModel.PostTags.Add(new PostTagModel { PostId = postModel.Id, TagName = "Tag 3" });

            var post = postModel.ToDomain();

            Assert.AreEqual(postModel.Id, post.Id);
            Assert.AreEqual(postModel.PostCategories[0].CategoryId, post.Categories[0]);
            Assert.AreEqual(postModel.PostTags[0].TagName, post.Tags[0]);
        }

        [Test]
        public void Should_map_domain_properties_to_data_model()
        {
        }
    }
}

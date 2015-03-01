using AutoMapper;
using Weapsy.Blog.Domain.Persistence.EF.Models;
using Weapsy.Blog.Domain.Posts;
using Weapsy.Blog.Infrastructure;

namespace Weapsy.Blog.Domain.Persistence.EF.Tasks
{
    public class AutoMapperStartupTask : IStartupTask
    {
        public void Execute()
        {
            Mapper.CreateMap<BlogModel, Blog.Blog>();
            Mapper.CreateMap<CategoryModel, Category.Category>();
            Mapper.CreateMap<PostModel, Post>()
                .ForMember(dst => dst.Categories, opt => opt.Ignore())
                .ForMember(dst => dst.Tags, opt => opt.Ignore());
            Mapper.CreateMap<CommentModel, Comment.Comment>();
        }

        protected virtual void ViceVersa<T1, T2>()
        {
            Mapper.CreateMap<T1, T2>();
            Mapper.CreateMap<T2, T1>();
        }
    }
}
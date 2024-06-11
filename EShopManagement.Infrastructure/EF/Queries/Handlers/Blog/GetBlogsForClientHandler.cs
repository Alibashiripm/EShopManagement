using AutoMapper;
using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Application.Queries.Blog;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Blog
{
    internal sealed class GetAllBlogCommentsForAdminHandler : IQueryHandler<GetBlogsForClient, List<ClientBlogsListDto>>
    {
        private readonly DbSet<Domain.Entities.Blog.Blog> _blogs;
     

        public GetAllBlogCommentsForAdminHandler(ReadDbContext context)
        {
            _blogs = context.Blogs;

        }
        public async Task<List<ClientBlogsListDto>> HandleAsync(GetBlogsForClient query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;
 
            var filteredBlogs = _blogs
                
                .AsQueryable();

             var result =   filteredBlogs
                .AsEnumerable() 
                .Where(b => b._title.Value.Contains(query.SearchPhrase) ||
                            b.Tags.Contains(query.SearchPhrase))
                .OrderBy(o => o._createDate.Value)
                .Skip(skip)
                .Take(query.TakeNumber)
                .Select(s => s.AsClientBlogsListDto())
                .ToList ();

            return result;
        } 
    }
}

using AutoMapper;
using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Application.Queries.Blog;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Blog
{
    internal sealed class GetAllBlogCommentsForAdminHandler : IQueryHandler<GetBlogsForClient, List<ClientBlogsListDto>>
    {
        private readonly DbSet<BlogReadModel> _blogs;
     

        public GetAllBlogCommentsForAdminHandler(ReadDbContext context)
        {
            _blogs = context.Blogs;

        }
        public async Task<List<ClientBlogsListDto>> HandleAsync(GetBlogsForClient query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;
           return await _blogs
                .Where(b=>b.Title.Contains(query.SearchPhrase)|| b.Tags.Tags.Contains(query.SearchPhrase))
                .OrderBy(o=>o.CreateDate)
                .Skip(skip)
                .Take(query.TakeNumber)
                .Select(s => s.AsClientBlogsListDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }    }

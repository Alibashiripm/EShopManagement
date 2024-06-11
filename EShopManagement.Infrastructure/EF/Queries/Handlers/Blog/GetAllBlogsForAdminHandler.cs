using AutoMapper;
using Azure;
using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Application.Queries.Blog;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Blog
{
    internal sealed class GetAllBlogsForAdminHandler : IQueryHandler<GetAllBlogsForAdmin, List<AdminBlogsListDto>>
    {
        private readonly DbSet<Domain.Entities.Blog.Blog> _blogs;
    

        public GetAllBlogsForAdminHandler(ReadDbContext context)
        {
            _blogs = context.Blogs;
     
        }
        public async Task<List<AdminBlogsListDto>> HandleAsync(GetAllBlogsForAdmin query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;
           return await _blogs
                .Where(b=>b._title.Value.Contains(query.SearchPhrase)|| b.Tags.Contains(query.SearchPhrase))
                .OrderBy(o=>o._createDate.Value)
                .Skip(skip)
                .Take(query.TakeNumber)
                .Select(s => s.AsAdminBlogsListDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

using EShopManagement.Domain.Entities.Blog;
using System;
using EShopManagement.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopManagement.Domain.ValueObjects.Blog;

namespace EShopManagement.Domain.Factories.Blog
{
    public interface IBlogFactory
    {
        EShopManagement.Domain.Entities.Blog.Blog Create(string ImageName,BlogTitle title, BlogContent content, BlogShortDescription shortDescription,
              string tags, BlogCreateDate createDate, BlogUpdateTime? updateDate, bool isDeleted);
    }
}

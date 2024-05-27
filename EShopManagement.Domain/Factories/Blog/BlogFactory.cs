using EShopManagement.Domain.ValueObjects.Blog;


namespace EShopManagement.Domain.Factories.Blog
{
    public sealed class BlogFactory : IBlogFactory
    {
        public Entities.Blog.Blog Create(string ImageName, BlogTitle title, BlogContent content, BlogShortDescription shortDescription, string tags, BlogCreateDate createDate, BlogUpdateTime? updateDate, bool isDeleted)
        => new(title,
               content,
               shortDescription,
               tags,
               createDate,
               updateDate,
               isDeleted,
               ImageName);
    }
}


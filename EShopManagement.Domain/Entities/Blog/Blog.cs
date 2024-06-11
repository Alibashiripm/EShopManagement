using EShopManagement.Shared.Abstractions.Domain;
using EShopManagement.Domain.ValueObjects.Blog;
using EShopManagement.Domain.ValueObjects.Product;
using System.Xml.Linq;

namespace EShopManagement.Domain.Entities.Blog
{
    public class Blog: AggregateRoot<int>
    {
        public int Id { get; private set; }
        public BlogTitle _title;
        public BlogContent _content;
        public BlogShortDescription _shortDescription;
        public string Tags { get;private set;}
        public string ImageName { get; private set; }
        public BlogCreateDate _createDate ;
        public BlogUpdateTime? _updateDate ;
        public bool IsDeleted { get; private set; } 
        
        #region Relation
        public List<BlogComment> BlogComments { get; set; }
        #endregion
        public Blog()
        {
            
        }
        internal Blog(BlogTitle title, BlogContent content, BlogShortDescription shortDescription,
              string tags, BlogCreateDate createDate, BlogUpdateTime? updateDate, bool isDeleted, string imageName)
        {
            ImageName = imageName;
             _title = title;
            _content = content;
            _shortDescription = shortDescription;
            Tags = tags;
            _createDate = createDate;
            _updateDate = updateDate;
            IsDeleted = isDeleted;
        }

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}

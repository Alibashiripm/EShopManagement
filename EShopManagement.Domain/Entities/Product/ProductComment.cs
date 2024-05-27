using EShopManagement.Shared.Abstractions.Domain;
using EShopManagement.Domain.ValueObjects.BlogComment;
using EShopManagement.Domain.ValueObjects.ProductComment;

namespace EShopManagement.Domain.Entities.Product
{
    public class ProductComment : AggregateRoot<int>
    {
        public int  Id { get; private set; }

        public ProductCommentContent _content;
        public ProductCommentCreateDate _createDate;
        public bool IsConfirmed { get; private set; }
        #region relations
        public long ProductId { get;private set; }
        public long UserId { get;private set; }
        public Product Product { get;private set; }
        public User.User User { get; private set; }
        #endregion
        public ProductComment(ProductCommentContent content, ProductCommentCreateDate createDate, bool isConfirmed,
                    long productId, long userId)
        {

            _content = content;
            _createDate = createDate;
            IsConfirmed = isConfirmed;
            ProductId = productId;
            UserId = userId;
        }
        public ProductComment()
        {

        }
        public void RemoveConfirmation()
        {
            IsConfirmed = false;
        }
        public void Confrim()
        {
            IsConfirmed = true;
        }
    }
}

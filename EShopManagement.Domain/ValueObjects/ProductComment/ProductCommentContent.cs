using EShopManagement.Domain.Exceptions;

namespace EShopManagement.Domain.ValueObjects.ProductComment
{
    public record ProductCommentContent
    {
        public string Value { get; }

        public ProductCommentContent(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("ProductContent");
            }

            Value = value;
        }


        public static implicit operator string(ProductCommentContent title)
            => title.Value;

        public static implicit operator ProductCommentContent(string title)
            => new(title);
    }
}

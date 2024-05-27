using EShopManagement.Domain.Exceptions;

namespace EShopManagement.Domain.ValueObjects.BlogComment
{
    public record BlogCommentContent
    {
        public string Value { get; }

        public BlogCommentContent(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("BlogCommentContent");
            }

            Value = value;
        }


        public static implicit operator string(BlogCommentContent title)
            => title.Value;

        public static implicit operator BlogCommentContent(string title)
            => new(title);
    }
}

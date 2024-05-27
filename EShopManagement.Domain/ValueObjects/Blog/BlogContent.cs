using EShopManagement.Domain.Exceptions;

namespace EShopManagement.Domain.ValueObjects.Blog
{
    public record BlogContent
    {
        public string Value { get; }

        public BlogContent(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("BlogContent");
            }

            Value = value;
        }


        public static implicit operator string(BlogContent title)
            => title.Value;

        public static implicit operator BlogContent(string title)
            => new(title);
    } 
    
}

using EShopManagement.Domain.Exceptions;

namespace EShopManagement.Domain.ValueObjects.Blog
{
    public record BlogShortDescription
    {
        public string Value { get; }

        public BlogShortDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("BlogShortDescription");
            }  
            if (value.Length > 200)
            {
                throw new InputTooLongException("BlogShortDescription",200);
            }

            Value = value;
        }


        public static implicit operator string(BlogShortDescription title)
            => title.Value;

        public static implicit operator BlogShortDescription(string title)
            => new(title);
    }
}

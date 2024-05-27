using EShopManagement.Domain.Exceptions;

namespace EShopManagement.Domain.ValueObjects.Product
{
    public record ProductDescription
    {
        public string Value { get; }

        public ProductDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("ProductDescription");
            }

            Value = value;
        }


        public static implicit operator string(ProductDescription title)
            => title.Value;

        public static implicit operator ProductDescription(string title)
            => new(title);
    }
}

using EShopManagement.Domain.Exceptions;

namespace EShopManagement.Domain.ValueObjects.Product
{
    public record ProductShortDescription
    {
        public string Value { get; }

        public ProductShortDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("ProductShortDescription");
            }
            if (value.Length > 200)
            {
                throw new InputTooLongException("ProductShortDescription", 200);
            }

            Value = value;
        }


        public static implicit operator string(ProductShortDescription title)
            => title.Value;

        public static implicit operator ProductShortDescription(string title)
            => new(title);
    }
}

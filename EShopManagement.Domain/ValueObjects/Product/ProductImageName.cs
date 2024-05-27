using EShopManagement.Domain.Exceptions;

namespace EShopManagement.Domain.ValueObjects.Product
{
    public record ProductImageName
    {
        public string Value { get; }

        public ProductImageName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("ProductImageName");
            }
            Guid guid = Guid.NewGuid();
 
            Value = (guid.ToString() + value).Trim();
        }


        public static implicit operator string(ProductImageName title)
            => title.Value;

        public static implicit operator ProductImageName(string title)
            => new(title);
    }
}

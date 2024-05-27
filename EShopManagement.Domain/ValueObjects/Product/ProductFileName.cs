using EShopManagement.Domain.Exceptions;

namespace EShopManagement.Domain.ValueObjects.Product
{
    public record ProductFileName
    {
        public string Value { get; }

        public ProductFileName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("ProductFileName");
            }
            Guid guid = Guid.NewGuid();
 
            Value = (guid.ToString() + value).Trim();
        }


        public static implicit operator string(ProductFileName title)
            => title.Value;

        public static implicit operator ProductFileName(string title)
            => new(title);
    }
}

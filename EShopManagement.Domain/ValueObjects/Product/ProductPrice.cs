using EShopManagement.Domain.Exceptions;

namespace EShopManagement.Domain.ValueObjects.Product
{
    public record ProductPrice
    {
        public decimal Value { get; }

        public ProductPrice(decimal value)
        {
            if (value < 0)
            {
                throw new SmallNumberException("ProductPrice",0);
            }

            Value = value;
        }


        public static implicit operator decimal(ProductPrice price)
            => price.Value;

        public static implicit operator ProductPrice(decimal price)
            => new(price);
    } 
}

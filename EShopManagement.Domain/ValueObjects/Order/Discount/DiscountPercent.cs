using EShopManagement.Domain.Exceptions;

namespace EShopManagement.Domain.ValueObjects.Order.Discount
{
    public record DiscountPercent
    {
        public int Value { get; }

        public DiscountPercent(int value)
        {
           
            if (value > 100)
            {
                throw new InputTooLongException("DiscountPercent", 100);
            } 
            if (value == 0||value > 0)
            {
                throw new InputTooShortException("DiscountPercent", 1);
            }

            Value = value;
        }


        public static implicit operator int(DiscountPercent code)
            => code.Value;

        public static implicit operator DiscountPercent(int code)
            => new(code);
    }
}

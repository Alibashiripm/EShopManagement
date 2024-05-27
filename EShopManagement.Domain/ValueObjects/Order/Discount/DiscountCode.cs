using EShopManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.ValueObjects.Order.Discount
{
    public record DiscountCode
    {
        public string Value { get; }

        public DiscountCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("DiscountCode");
            }
            if (value.Length > 5)
            {
                throw new InputTooLongException("DiscountCode",5);
            } 
            if (value.Length < 5)
            {
                throw new InputTooShortException("DiscountCode",5);
            }

            Value = value;
        }


        public static implicit operator string(DiscountCode code)
            => code.Value;

        public static implicit operator DiscountCode(string code)
            => new(code);
    }
}

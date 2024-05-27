using EShopManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.ValueObjects.Product
{
    public record ProductTitle
    {
        public string Value { get; }

        public ProductTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("ProductTitle");
            }

            Value = value.Replace(" ", "_");
        }


        public static implicit operator string(ProductTitle title)
            => title.Value;

        public static implicit operator ProductTitle(string title)
            => new(title);
    } 
}

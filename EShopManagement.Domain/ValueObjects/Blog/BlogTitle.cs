using EShopManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.ValueObjects.Blog
{
    public record BlogTitle
    {
        public string Value { get; }

        public BlogTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullStringInputException("BlogTitle");
            }

            Value = value.Replace(" ","_");
        }


        public static implicit operator string(BlogTitle title)
            => title.Value;

        public static implicit operator BlogTitle(string title)
            => new(title);
    }
}

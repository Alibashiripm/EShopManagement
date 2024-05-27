using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.ValueObjects.ProductComment
{

    public record ProductCommentCreateDate
    {
            public DateTime Value { get; }

            public ProductCommentCreateDate(DateTime date)
            {
                Value = date;
            }

            public static implicit operator string(ProductCommentCreateDate date)
            {
                PersianCalendar pc = new PersianCalendar();
                return pc.GetYear(date.Value) + "/" + pc.GetMonth(date.Value).ToString("00") + "/" +
                       pc.GetDayOfMonth(date.Value).ToString("00");
            }
        public static implicit operator ProductCommentCreateDate(DateTime date)
          => new(date);
 
}
}

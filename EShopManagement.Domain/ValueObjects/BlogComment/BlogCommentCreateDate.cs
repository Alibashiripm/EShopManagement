using EShopManagement.Domain.ValueObjects.Blog;
using System.Globalization;

namespace EShopManagement.Domain.ValueObjects.BlogComment
{
    public record BlogCommentCreateDate
    {
        public DateTime Value { get; }

        public BlogCommentCreateDate(DateTime date)
        {
            Value = date;
        }

        public static implicit operator string(BlogCommentCreateDate date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date.Value) + "/" + pc.GetMonth(date.Value).ToString("00") + "/" +
                   pc.GetDayOfMonth(date.Value).ToString("00");
        }
        public static implicit operator BlogCommentCreateDate(DateTime date)
     => new(date);
    }
}

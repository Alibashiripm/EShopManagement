using System.Globalization;

namespace EShopManagement.Domain.ValueObjects.Blog
{
 
    public record BlogUpdateTime
    {
        public DateTime Value { get; }

        public BlogUpdateTime(DateTime date)
        {
            Value = date;
        }

        public static implicit operator string(BlogUpdateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date.Value) + "/" + pc.GetMonth(date.Value).ToString("00") + "/" +
                   pc.GetDayOfMonth(date.Value).ToString("00");
        }
        public static implicit operator BlogUpdateTime(DateTime date)
        => new(date);
    }
}


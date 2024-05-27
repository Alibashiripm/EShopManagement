using System.Globalization;

namespace EShopManagement.Domain.ValueObjects.Blog
{
    public record BlogCreateDate
    {
        public DateTime Value { get; }

        public BlogCreateDate(DateTime date)
        {
            Value = date;
        }

        public static implicit operator string(BlogCreateDate date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date.Value) + "/" + pc.GetMonth(date.Value).ToString("00") + "/" +
                   pc.GetDayOfMonth(date.Value).ToString("00");
        }
        public static implicit operator BlogCreateDate(DateTime date)
        => new(date);
    }  
}


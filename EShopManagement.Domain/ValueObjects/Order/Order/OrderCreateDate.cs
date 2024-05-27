using System.Globalization;

namespace EShopManagement.Domain.ValueObjects.Order
{
    public record OrderCreateDate
    {
        public DateTime Value { get; }

        public OrderCreateDate(DateTime date)
        {
            Value =date;
        }

        public static implicit operator string(OrderCreateDate date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date.Value) + "/" + pc.GetMonth(date.Value).ToString("00") + "/" +
                   pc.GetDayOfMonth(date.Value).ToString("00");
        }
        public static implicit operator OrderCreateDate(DateTime date)
       => new(date);
    }  
}


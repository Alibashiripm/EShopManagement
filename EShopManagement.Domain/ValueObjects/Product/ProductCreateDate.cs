using System.Globalization;

namespace EShopManagement.Domain.ValueObjects.Blog
{
    public record ProductCreateDate
    {
        public DateTime Value { get; }

        public ProductCreateDate(DateTime date)
        {
            Value = date;
        }

        public static implicit operator string(ProductCreateDate date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date.Value) + "/" + pc.GetMonth(date.Value).ToString("00") + "/" +
                   pc.GetDayOfMonth(date.Value).ToString("00");
        }
        public static implicit operator ProductCreateDate(DateTime date)
      => new(date);
 
 
}
}


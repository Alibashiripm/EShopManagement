using System.Globalization;

namespace EShopManagement.Domain.ValueObjects.Blog
{
    public record ProductUpdateDate
    {
        public DateTime Value { get; }

        public ProductUpdateDate(DateTime date)
        {
            Value = date;
        }

        public static implicit operator string(ProductUpdateDate date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date.Value) + "/" + pc.GetMonth(date.Value).ToString("00") + "/" +
                   pc.GetDayOfMonth(date.Value).ToString("00");
        }
        public static implicit operator ProductUpdateDate(DateTime date)
      => new(date);

    }
}


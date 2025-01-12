using System.Globalization;

namespace PetShop.Application.Utility
{
    public static class DateConvertor
    {
        public static string Toshamsi(this DateTime dateTime)
        {
            PersianCalendar persian = new PersianCalendar();
            string year = persian.GetYear(dateTime).ToString();
            string month = persian.GetMonth(dateTime).ToString("00");
            string day = persian.GetDayOfMonth(dateTime).ToString("00");

            return year + "/" + month + "/" + day;
        }
    }
}
namespace PetShop.Application.Utility
{
    public class Utilities
    {
        public static string GetCompleteSubstring(string text, int maxLength)
        {
            if (text.Length <= maxLength)
            {
                return text;
            }

            // گرفتن زیررشته اولیه با طول مشخص
            string substring = text.Substring(0, maxLength);

            // پیدا کردن آخرین فاصله (space) در زیررشته
            int lastSpaceIndex = substring.LastIndexOf(' ');

            // اگر فاصله‌ای پیدا نشد، زیررشته اولیه را برگردانید
            if (lastSpaceIndex == -1)
            {
                return substring;
            }

            // برگرداندن زیررشته تا آخرین فاصله
            return substring.Substring(0, lastSpaceIndex);
        }

        public static List<type> pagging<type>(List<type> instanc, int page, out double pageCount, int take = 3)
        {
            int skip = (page - 1) * take;
            var result = instanc?.
           Skip(skip).Take(take).ToList();
            pageCount = (double)Math
                .Ceiling((double)instanc.Count() / take);
            return result ?? new List<type>();
        }
    }
}
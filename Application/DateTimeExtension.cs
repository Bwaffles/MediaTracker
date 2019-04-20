using System;

namespace Application
{
    public static class DateTimeExtension
    {
        public static string PrettyDate(this DateTime? source)
        {
            if (!source.HasValue)
                return "Unknown";
            
            int dayDiff = (int)DateTime.Now.Subtract(source.Value).TotalDays;

            switch(dayDiff)
            {
                case var testDiff when testDiff < 0:
                    return "Unknown";
                case var testDiff when testDiff <= 1:
                    return "Yesterday";
                case var testDiff when testDiff <= 6:
                    return string.Format($"{testDiff} days ago");
                case var testDiff when testDiff <= 13:
                    return string.Format("1 week ago");
                default:
                    return string.Format($"{Math.Floor((double)dayDiff / 7)} weeks ago");

            }
        }
    }
}

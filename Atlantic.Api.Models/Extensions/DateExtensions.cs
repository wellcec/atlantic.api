using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using TimeZoneConverter;

namespace Atlantic.Api.Models.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DateExtensions
    {
        private const string FORMAT_DATE = "dd/MM/yyyy HH:mm";

        public static DateTime GetBrasiliaDateTime(this DateTime date)
        {
            TimeZoneInfo hrBrasilia = TZConvert.GetTimeZoneInfo(Constants.TIME_ZONE_INFO);
            return TimeZoneInfo.ConvertTimeFromUtc(date, hrBrasilia);
        }
        public static int GetMinutesUntil(this string dateTimeStr)
        {
            var provider = CultureInfo.InvariantCulture;

            var targetDate = DateTime.ParseExact(dateTimeStr, FORMAT_DATE, provider);
            var now = GetBrasiliaDateTime(DateTime.UtcNow);

            var diff = targetDate - now;

            return diff.TotalMinutes > default(int) ? (int)diff.TotalMinutes : default(int);
        }
    }
}

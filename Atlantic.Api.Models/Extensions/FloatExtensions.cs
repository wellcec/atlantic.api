using System;

namespace Atlantic.Api.Models.Extensions
{
    public static class FloatExtensions
    {
        private const int REAL_TO_CENT_CONVERSION = 100;

        public static int ToCents(this float value)
        {
            return Convert.ToInt32(value * REAL_TO_CENT_CONVERSION);
        }
    }
}

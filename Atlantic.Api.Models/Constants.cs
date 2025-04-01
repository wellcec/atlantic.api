using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace Atlantic.Api.Models
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const string PROJECT_NAME = "Atlantic.Api";

        public const int REDIS_DAYS = 30;
        public const int REDIS_TRACED_DAYS = 4;

        public const int PRODUCTS_DEFAULT_PAGE = 1;
        public const int PRODUCTS_DEFAULT_TAKE = 20;

        public const string ASTERISK = "*";
        
        public const string BLIP_USER_HEADER = "X-Blip-User";
        public const string XML_EXTENSION = ".xml";

        // Time
        public const string TIME_ZONE_INFO = "America/Sao_Paulo";
        public const string DATE_FORMAT = "dd/MM/yyyy";
        public const string DATE_TIME_FORMAT = "dd/MM/yyyy HH:mm";
        public const string TIME_FORMAT = "t";
        public const string FORMAT_DATE = "yyyy-MM-ddTHH:mm:ss.fffZ";

        public const string FORMAT_DATE_TIMEZONE = "yyyy-MM-ddTHH:mm:ss.fffZ";
        public const string FORMAT_DATE_TIMEZONE_CUSTOM = "yyyy-MM-ddTHH:mm:ss.fffffff";
        public const string FORMAT_DATE_TIMEZONE_CUSTOM_1 = "yyyy-MM-ddTHH:mm:ss.fffffffzzz";
        public const string FORMAT_DATE_TIMEZONE_CUSTOM_2 = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
        public const string FORMAT_DATE_TIMEZONE_CUSTOM_3 = "yyyy-MM-ddTHH:mm:ssZ";
        public const string FORMAT_DATE_TIMEZONE_CUSTOM_4 = "yyyy-MM-dd HH:mm:ss";

        // Bucket
        public const string BUCKET_NAME = "atlantic-bucket";
    }
}

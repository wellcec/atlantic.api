using System.Net;

namespace Atlantic.Api.Models.Responses
{
    public class BaseListResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
    }
}

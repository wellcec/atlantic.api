using System.Net;

namespace Atlantic.Api.Models.Responses
{
    public class BaseResponse
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}

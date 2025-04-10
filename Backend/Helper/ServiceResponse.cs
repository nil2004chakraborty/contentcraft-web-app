
using static Blog.Helper.Enum;

namespace Blog.Helper
{
    public class ServiceResponse<T>
    {
        public T result { get; set; }
        public APIResponseStatus ApiResponseStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}

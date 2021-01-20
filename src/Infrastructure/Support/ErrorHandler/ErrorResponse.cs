using Newtonsoft.Json;

namespace Infrastructure.Support.ErrorHandler
{
    public class ErrorResponse
    {
        public string Description { get; set; }
        public object Error { get; set; }

        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

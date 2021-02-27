using System.Collections.Generic;
using System.Linq;

namespace RxCore.ApiModule
{
    public class RxApiResponse<T>
    {
        public string Status { get; set; } = "";
        public List<Message> Messages { get; set; } = new List<Message>();
        public T Content { get; set; } = default!;
        public Dictionary<string, string> Attributes = new Dictionary<string, string>();

        public static RxApiResponse<T> CreateInvalidResponse(string status, ValidateResult validateResult)
        {
            return new RxApiResponse<T>
            {
                Status = status,
                Messages = validateResult.Messages
            };
        }

        public static RxApiResponse<T> CreateResponse(string status, string message = "")
        {
            var response = new RxApiResponse<T>()
            {
                Status = status
            };

            if (!string.IsNullOrEmpty(message))
                response.Messages.Add(new Message(message));
            
            return response;
        }
    }
}
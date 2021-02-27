using System.Collections.Generic;

namespace RxCore.ApiModule
{
    public class ValidateResult
    {
        public bool IsValid { get; set; } = false;
        public List<Message> Messages{ get; set; } = new List<Message>();
    }
}
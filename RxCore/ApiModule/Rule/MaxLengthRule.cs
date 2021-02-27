using System;
using System.ComponentModel.DataAnnotations;

namespace RxCore.ApiModule.Rule
{
    public class MaxLengthRule<T> : IValidateRule<T>
    {
        public const string MessageDescription = "Длина должна быть меньше {0}";
        private readonly Func<T,string> _func;
        private readonly int _length;
        private readonly string _message;

        private readonly string _field;

        public MaxLengthRule(string fieldName, Func<T,string> func, int length, string messageMin = MessageDescription)
        {
            _field = fieldName;
            _func = func;
            _length = length;
            _message = messageMin;
        }
        
        public string Message()
        {
            return string.Format(_message, _length);
        }

        public string MessageId()
        {
            return _field;
        }

        public bool Validate(T data)
        {
            var val = _func.Invoke(data) ?? "";
            return new MaxLengthAttribute(_length).IsValid(val);
        }
    }
}
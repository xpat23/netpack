using System;
using System.ComponentModel.DataAnnotations;

namespace RxCore.ApiModule.Rule
{
    public class RegexRule<T> : IValidateRule<T>
    {
        public const string MessageDescription = "Некоректный формат данных";
        private readonly Func<T,string> _func;
        private readonly string _pattern;
        private readonly string _message;
        
        private readonly string _field;

        public RegexRule(string fieldName, Func<T,string> func, string pattern, string message = MessageDescription)
        {
            _field = fieldName;
            _func = func;
            _pattern = pattern;
            _message = message;
        }
        
        public string Message()
        {
            return _message;
        }

        public string MessageId()
        {
            return _field;
        }

        public bool Validate(T data)
        {
            var val = _func.Invoke(data);
            return new RegularExpressionAttribute(_pattern).IsValid(val);
        }
    }
}
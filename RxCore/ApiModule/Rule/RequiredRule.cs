using System;
using System.ComponentModel.DataAnnotations;

namespace RxCore.ApiModule.Rule
{
    public class RequiredRule<T>: IValidateRule<T>
    {
        public const string MessageDescription = "Значение не должно быть пустым";
        private readonly Func<T,string> _func;
        private readonly string _message;
        
        private readonly string _field;

        public RequiredRule(string fieldName, Func<T,string> func, string message = MessageDescription)
        {
            _field = fieldName;
            _func = func;
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
            return new RequiredAttribute().IsValid(val);
        }
    }
}
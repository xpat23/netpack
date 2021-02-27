using System.Collections.Generic;
using System.Linq;

namespace RxCore.ApiModule
{
    public class DataValidator<T> : IDataValidator<T>
    {
        protected readonly List<IValidateRule<T>> _rules = new List<IValidateRule<T>>();


        public virtual void AddRule(IValidateRule<T> rule)
        {
            _rules.Add(rule);
        }

        public virtual ValidateResult Validate(T data)
        {
            var result = new ValidateResult
            {
                Messages = _rules
                    .Where(rule => !rule.Validate(data))
                    .Select(rule => new Message(rule.Message(), rule.MessageId()))
                    .ToList()
            };

            result.IsValid = result.Messages.Count == 0;

            return result;
        }
    }
}
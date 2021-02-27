using System.Collections.Generic;

namespace RxCore.ApiModule
{
    public interface IDataValidator<T>
    {
        public void AddRule(IValidateRule<T> rule);

        public abstract ValidateResult Validate(T data);
    }
}
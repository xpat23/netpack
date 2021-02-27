namespace RxCore.ApiModule
{
    public interface IValidateRule<in T>
    {
        public string Message();

        public string MessageId();

        public bool Validate(T data);
    }
}
namespace enoca_NET_case.Exceptions
{
    public class ValidationNotValidException: Exception
    {
        public ValidationNotValidException(string message)
        {
            Message = message;
        }
        
        public override string Message { get; }
    }
}

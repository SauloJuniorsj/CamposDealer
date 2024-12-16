namespace CamposDealer.Domain.Exceptions
{
    public class DomainLogicException : Exception
    {
        public DomainLogicException(string message)
            : base(message)
        {
        }

        public DomainLogicException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

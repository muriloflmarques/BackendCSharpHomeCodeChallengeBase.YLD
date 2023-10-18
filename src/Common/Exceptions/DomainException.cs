namespace GamingApi.Common.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message, string propertyName)
        : base($"{message} - value of {propertyName}") { }
    }
}

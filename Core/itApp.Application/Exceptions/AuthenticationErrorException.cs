
namespace itApp.Application.Exceptions
{
    public class AuthenticationErrorException : Exception
    {
        public AuthenticationErrorException() : base("Giris Hatali")
        {
        }

        public AuthenticationErrorException(string? message) : base(message)
        {
        }
    }
}

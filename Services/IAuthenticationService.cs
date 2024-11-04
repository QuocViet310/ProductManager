using BusinessObjects.Models;

namespace Services
{
    public interface IAuthenticationService
    {
        
        User? Authenticate(string username, string password);
    }
}

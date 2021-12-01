using System.Threading.Tasks;

using HR.LeaveManagement.Mvc.Models;

namespace HR.LeaveManagement.Mvc.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> Register(RegisterVM register);

        Task Logout();
    }
}

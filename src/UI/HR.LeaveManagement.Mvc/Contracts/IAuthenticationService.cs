using System.Threading.Tasks;

using HR.LeaveManagement.Mvc.Models.User;

namespace HR.LeaveManagement.Mvc.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> Register(RegisterVm register);

        Task Logout();
    }
}

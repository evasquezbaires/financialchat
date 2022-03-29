using FinancialChat.App.Models;
using System.Threading.Tasks;

namespace FinancialChat.App.Contracts
{
    public interface IAuthService
    {
        Task<int> Register(RegisterModel registerModel);

        Task<string> Login(LoginModel loginModel);

        Task Logout();
    }
}

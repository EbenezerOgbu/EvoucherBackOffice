using EvoucherBackOffice.Services.DTObjects.Account;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services
{
    public interface IAccountService
    {
        Task<string> Login(LoginDTO login);
        Task<bool> RequestPasswordReset(ForgotPasswordDTO forgotPassword);
        Task<bool> ResetPassword(ResetPasswordDTO resetPassword);
    }
}

using EvoucherBackOffice.Services.DTObjects.Account;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services
{
    public interface IAccountService
    {
        Task Login(LoginDTO login);
        Task RequestPasswordReset(ForgotPasswordDTO forgotPassword);
        Task ResetPassword(ResetPasswordDTO resetPassword);
    }
}

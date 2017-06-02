using EvoucherBackOffice.Services;
using EvoucherBackOffice.Web.ViewModel.Account;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                return View();
            }
            catch (System.Exception)
            {
                throw;
            }           
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }

                return View(model);
            }
            catch (System.Exception)
            {
                throw;
            }       
        }

        public ActionResult ForgotPasswordConfirmation()
        {
            try
            {
                return View();
            }
            catch (System.Exception)
            {
                throw;
            }           
        }

        public ActionResult ResetPassword(string code)
        {
            try
            {
                return code == null ? View("Error") : View();
            }
            catch (System.Exception)
            {
                throw;
            }      
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                return View();
            }
            catch (System.Exception)
            {
                throw;
            }        
        }

        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
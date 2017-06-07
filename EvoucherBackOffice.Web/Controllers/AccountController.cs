using EvoucherBackOffice.Services;
using EvoucherBackOffice.Services.DTObjects.Account;
using EvoucherBackOffice.Web.ViewModel.Account;
using System;
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
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                var loginViewModel = new LoginViewModel();
                if (TryUpdateModel(loginViewModel))
                {
                    var loginDTO = new LoginDTO
                    {
                        Email = loginViewModel.Email,
                        Password = loginViewModel.Password
                    };
                    var authToken =  _accountService.Login(loginDTO).Result;
                    if (!string.IsNullOrEmpty(authToken))
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "there is a problem with this operation.");
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "This operation could not be completed, please try again.");
                return View();
            }           
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(FormCollection collection)
        {
            try
            {
                var forgotPasswordViewModel = new ForgotPasswordViewModel();
                if (TryUpdateModel(forgotPasswordViewModel))
                {
                    var forgotPasswordDTO = new ForgotPasswordDTO
                    {
                        Email = forgotPasswordViewModel.Email,                      
                    };
                    var response = _accountService.RequestPasswordReset(forgotPasswordDTO).Result;
                    if (response)
                    {
                        return RedirectToAction("ForgotPasswordConfirmation");
                    }
                    else
                    {
                        ModelState.AddModelError("", "There is a problem with this operation.");
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "This operation could not be completed, please try again.");
                return View();
            }
        }

        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        public ActionResult ResetPassword(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                HttpContext.Session["resetcode"] = code;
            }
            var model = new ResetPasswordViewModel();
            return View(model);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(FormCollection collection)
        {
            try
            {
                var resetcode = (string)HttpContext.Session["resetcode"];
                var resetPasswordViewModel = new ResetPasswordViewModel();
                if (TryUpdateModel(resetPasswordViewModel))
                {
                    var resetPasswordDTO = new ResetPasswordDTO
                    {
                        Email = resetPasswordViewModel.Email,
                        Password = resetPasswordViewModel.Password,
                        ConfirmPassword = resetPasswordViewModel.ConfirmPassword,
                        Code = resetcode                     
                    };
                    var response = _accountService.ResetPassword(resetPasswordDTO).Result;
                    if (response)
                    {
                        return RedirectToAction("ResetPasswordConfirmation");
                    }
                    else
                    {
                        ModelState.AddModelError("", "There is a problem with this operation.");
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "This operation could not be completed, please try again.");
                return View();
            }
        }

        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
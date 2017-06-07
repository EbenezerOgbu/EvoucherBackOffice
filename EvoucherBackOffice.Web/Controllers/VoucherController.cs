using EvoucherBackOffice.Services;
using EvoucherBackOffice.Services.DTObjects.Voucher;
using EvoucherBackOffice.Web.ViewModel;
using System;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.Controllers
{
    public class VoucherController : Controller
    {
        private readonly IVoucherService _voucherService;
        private VoucherDetailViewModel _voucherDetailViewModel;
        private BasketViewModel _basketViewModel;
        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        public ActionResult ConfirmVoucher()
        {
            var model = new ConfirmVoucherViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult ConfirmVoucher(ConfirmVoucherViewModel confirmVoucher)
        {
            try
            {
                if (string.IsNullOrEmpty(confirmVoucher.VoucherToken))
                {
                    var voucherDetail = _voucherService.GetVoucher(confirmVoucher.VoucherToken).Result;
                    var model = new VoucherDetailViewModel
                    {
                        VoucherToken = voucherDetail.voucherToken,
                        VoucherDescription = voucherDetail.voucherDescription,
                        Name = voucherDetail.name,
                        VoucherPurchasedOn = voucherDetail.voucherPurchasedOn,
                        UsedOn = voucherDetail.usedOn
                    };
                    _voucherDetailViewModel = model;
                    return RedirectToAction("DisplayVoucher");
                }
                else
                {
                    ModelState.AddModelError("", "there is a problem with this operation.");
                    return View();
                }                             
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "This operation could not be completed, please try again.");
                return View();
            }          
        }
        public ActionResult DisplayVoucher()
        {
            return View(_voucherDetailViewModel);
        }
    
        public ActionResult RedeemVoucher(VoucherDetailViewModel voucherDetail)
        {
            try
            {
                if (voucherDetail != null)
                {
                    _voucherService.RedeemVoucher(voucherDetail.VoucherToken);
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "there is a problem with this operation.");
                    return View();
                }       
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "This operation could not be completed, please try again.");
                return View();
            }        
        }
        public ActionResult CreateNewVoucher()
        {
            return RedirectToAction("Experiences", "Experience", new { area = "" });
        }

        public ActionResult PostNewOrder()
        {        
            try
            {
                var basket = (BasketViewModel)HttpContext.Session["basket"];
                if (basket != null)
                {
                    _basketViewModel = basket;
                }
                CreateAndPostOrder(_voucherService);
                return RedirectToAction("DisplayVoucher");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }          
        }
        public ActionResult VoucherNotFound()
        {
            return View();
        }

        private void CreateAndPostOrder(IVoucherService voucherService)
        {
            var createVoucher = new CreateVoucherDTO
            {
               vouchertypeId = Properties.Settings.Default.VoucherTypeId,
               maxRedemptions = 0,
               firstName = _basketViewModel.CustomerDetail.FirstName,
               lastName = _basketViewModel.CustomerDetail.SecondName,
               email = _basketViewModel.CustomerDetail.Email
            };
            var voucherDetail =  voucherService.CreateVoucher(createVoucher).Result;
            var model = new VoucherDetailViewModel
            {
                VoucherToken = voucherDetail.voucherToken,
                VoucherDescription = voucherDetail.voucherDescription,
                Name = voucherDetail.name,
                VoucherPurchasedOn = voucherDetail.voucherPurchasedOn,
                UsedOn = voucherDetail.usedOn
            };
            _voucherDetailViewModel = null;
            _voucherDetailViewModel = model;
        }
    }
}
using EvoucherBackOffice.Services;
using EvoucherBackOffice.Services.DTObjects.Voucher;
using EvoucherBackOffice.Web.Models;
using EvoucherBackOffice.Web.ViewModel;
using System;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.Controllers
{
    public class VoucherController : Controller
    {
        private readonly IVoucherService _voucherService;
        private readonly ICart _cart;
        private VoucherDetailViewModel _voucherDetailViewModel;
        private CustomerDetailViewModel _customerDetailViewModel;
        public VoucherController(IVoucherService voucherService, ICart cart)
        {
            _cart = cart;
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
                if (!string.IsNullOrEmpty(confirmVoucher.VoucherToken))
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

        public ActionResult CreateAndUseNow()
        {        
            try
            {
                var customerDetail = (CustomerDetailViewModel)HttpContext.Session["customerDetail"];
                if (customerDetail != null)
                {
                    _customerDetailViewModel = customerDetail;
                }
                //CreateAndPostOrder(_voucherService);
                return RedirectToAction("DisplayVoucher");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }          
        }

        public ActionResult CreateAndUseLater()
        {
            try
            {
                var customerDetail = (CustomerDetailViewModel)HttpContext.Session["customerDetail"];
                if (customerDetail != null)
                {
                    _customerDetailViewModel = customerDetail;
                }
                CreateAndPostOrder(_voucherService);
                return View("NewVoucherConfirmation");
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
               firstName = _customerDetailViewModel.FirstName,
               lastName = _customerDetailViewModel.SecondName,
               email = _customerDetailViewModel.Email
            };

            foreach (var itemLine in _cart.Lines)
            {
                var attribute = new AttributeDTO
                {
                    attributeId = itemLine.Experience.Code,
                    value = itemLine.Quantity.ToString(),
                };
                createVoucher.attributes.Add(attribute);
            }

            var voucherDetail =  voucherService.CreateVoucher(createVoucher).Result;

            _cart.Clear();

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
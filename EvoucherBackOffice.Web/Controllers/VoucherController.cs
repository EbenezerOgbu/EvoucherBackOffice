﻿using EvoucherBackOffice.Services;
using EvoucherBackOffice.Services.DTObjects;
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
            return View();
        }
        [HttpPost]
        public ActionResult ConfirmVoucher(ConfirmVoucherViewModel confirmVoucherViewModel)
        {
            try
            {
                var confirmVoucher = new ConfirmVoucherDTO
                {
                    voucherNumber = confirmVoucherViewModel.VoucherNumber
                };
                var voucherDetail = _voucherService.ConfirmVoucher(confirmVoucher).Result;
                var model = new VoucherDetailViewModel
                {
                    VoucherCode = voucherDetail.voucherCode,
                    VoucherDescription = voucherDetail.voucherDescription,
                    Name = voucherDetail.name,
                    VoucherPurchasedOn = voucherDetail.voucherPurchasedOn,
                    UsedOn = voucherDetail.usedOn
                };
                _voucherDetailViewModel = model;
                return RedirectToAction("DisplayVoucher");
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
    
        public ActionResult RedeemVoucher(VoucherDetailViewModel voucherDetailViewModel)
        {
            try
            {
                var redeemVoucher = new RedeemVoucherDTO
                {
                    voucherNumber = voucherDetailViewModel.VoucherCode
                };
                _voucherService.RedeemVoucher(redeemVoucher);
                return View();
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
            var customerDetail = new CustomerDetailDTO
            {
                FirstName = _basketViewModel.CustomerDetail.FirstName,
                FamilyName = _basketViewModel.CustomerDetail.SecondName,
                Email = _basketViewModel.CustomerDetail.Email
            };
            var order = new OrderDTO
            {
                Code = _basketViewModel.Experience.Code,
                Qty = _basketViewModel.Quantity,
                Amount = _basketViewModel.LineTotal,
                CreatedOn = DateTime.Now,
                CustomerDetail = customerDetail
            };
            var voucherDetail =  voucherService.PostOrder(order).Result;
            var model = new VoucherDetailViewModel
            {
                VoucherCode = voucherDetail.voucherCode,
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
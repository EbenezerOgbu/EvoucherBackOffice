using EvoucherBackOffice.Services;
using EvoucherBackOffice.Web.ViewModel;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.Controllers
{
    public class VoucherController : Controller
    {
        private readonly IVoucherService _voucherService;
        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        public ActionResult ConfirmVoucher()
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
        [HttpPost]
        public ActionResult ConfirmVoucher(ConfirmVoucherViewModel model)
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
        public ActionResult DisplayVoucher()
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
        [HttpPost]
        public ActionResult RedeemVoucher()
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
        public ActionResult VoucherNotFound()
        {
            return View();
        }

        public ActionResult CreateVoucher()
        {
            return View();
        }
    }
}
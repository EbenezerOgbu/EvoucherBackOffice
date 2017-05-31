using EvoucherBackOffice.Web.ViewModel;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.Controllers
{
    public class VoucherController : Controller
    {       
        public ActionResult ConfirmVoucher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ConfirmVoucher(ConfirmVoucherViewModel model)
        {
            return View();
        }
        public ActionResult RedeemVoucher()
        {
            return View();
        }
        public ActionResult VoucherNotFound()
        {
            return View();
        }
        public ActionResult VoucherList()
        {
            return View();
        }
        public ActionResult CreateVoucher()
        {
            return View();
        }
    }
}
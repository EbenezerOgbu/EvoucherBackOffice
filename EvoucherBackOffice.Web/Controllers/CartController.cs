using EvoucherBackOffice.Web.Infrastructure;
using EvoucherBackOffice.Web.Models;
using EvoucherBackOffice.Web.ViewModel;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cart;
        private CustomerDetailViewModel _customerDetailViewModel;
        public CartController(ICart cart)
        {
            _cart = cart;
            _customerDetailViewModel= new CustomerDetailViewModel();
        }

        [HttpPost]
        public JsonResult AddToCart(JsonVoucherItem itemUpdate)
        {
            ExperiencesViewModel storedModel = (ExperiencesViewModel)HttpContext.Session["experiences"];

            ExperienceViewModel exp = storedModel.Experiences.Find(e => e.Code == itemUpdate.VoucherCode);

            _cart.AddItem(exp, itemUpdate.Qty);  
            return Json("OK");
        }

        [HttpPost]
        public JsonResult RemoveFromCart(JsonVoucherItem itemUpdate)
        {
            ExperiencesViewModel storedModel = (ExperiencesViewModel)HttpContext.Session["experiences"];

            ExperienceViewModel exp = storedModel.Experiences.Find(e => e.Code == itemUpdate.VoucherCode);

            _cart.RemoveItem(exp, itemUpdate.Qty);
        
            return Json("OK");
        }

        public ViewResult Checkout()
        {
            return View(_customerDetailViewModel);
        }

        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UseLater(FormCollection collection)
        {
            if (TryUpdateModel(_customerDetailViewModel))
            {
                HttpContext.Session["customerDetail"] = _customerDetailViewModel;
                return RedirectToAction("CreateAndUseLater", "Voucher", new { area = "" });
            }
            return RedirectToAction("Checkout");
        }

        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UseNow(FormCollection collection)
        {
            if (TryUpdateModel(_customerDetailViewModel))
            {
                HttpContext.Session["customerDetail"] = _customerDetailViewModel;
                return RedirectToAction("CreateAndUseNow", "Voucher", new { area = "" });
            }
            return RedirectToAction("Checkout");
        }
    }
}
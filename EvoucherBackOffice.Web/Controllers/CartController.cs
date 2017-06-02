using EvoucherBackOffice.Web.Models;
using EvoucherBackOffice.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cart;
        private BasketViewModel _basketViewModel;
        public CartController(ICart cart)
        {
            _cart = cart;
            _basketViewModel = new BasketViewModel();
        }
        public RedirectToRouteResult AddToCart(BasketItemViewModel basketItem)
        {
            if (basketItem != null)
            {
                _cart.AddItem(basketItem.Experience, basketItem.Quantity);
            }
            return RedirectToAction("Checkout");
        }

        public PartialViewResult BasketSummary()
        {
            return PartialView(_cart);
        }
        public ViewResult Checkout(CustomerDetailViewModel customerDetail = null)
        {
            _basketViewModel.Experience = _cart.Line.Experience;
            _basketViewModel.Quantity = _cart.Line.Quantity;
            _basketViewModel.CustomerDetail = customerDetail;
            return View(_basketViewModel);
        }

        [HttpPost]
        public ViewResult Checkout(string returnUrl, FormCollection collection)
        {
            if (TryUpdateModel(_basketViewModel))
            {
                if (_basketViewModel.Quantity > 0 && _basketViewModel.Quantity != _cart.Line.Quantity)
                {
                    _cart.AdjustQuantity(_basketViewModel.Quantity);
                }

                _basketViewModel.ReturnUrl = returnUrl;
                _basketViewModel.Experience = _cart.Line.Experience;
                _basketViewModel.LineTotal = _cart.ComputeTotalValue();

                HttpContext.Session["basket"] = _basketViewModel;

                return View("Review", _basketViewModel);
            }
            return View(_basketViewModel);
        }

        public ActionResult ClearBasket()
        {
            _cart.Clear();
            return RedirectToAction("List", "Experience", new { area = "" });
        }
    }
}
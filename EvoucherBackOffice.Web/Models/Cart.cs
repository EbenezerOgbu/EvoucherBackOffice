using EvoucherBackOffice.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvoucherBackOffice.Web.Models
{
    public class Cart : ICart
    {
        private CartLine _cartLine;
        public Cart()
        {
            _cartLine = new CartLine();
        }

        public void AddItem(ExperienceViewModel experience, int quantity)
        {
            _cartLine.Experience = experience;
            _cartLine.Quantity = quantity;
        }

        public void AdjustQuantity(int newQuantity)
        {
            _cartLine.Quantity = newQuantity;
        }
        public decimal ComputeTotalValue()
        {
            if (_cartLine.Experience == null)
            {
                var experience = new ExperienceViewModel();
                return experience.Price * _cartLine.Quantity;
            }
            return _cartLine.Experience.Price * _cartLine.Quantity;
        }
        public void Clear()
        {
            _cartLine.Quantity = 0;

        }
        public CartLine Line
        {
            get { return _cartLine; }
        }
    }
}
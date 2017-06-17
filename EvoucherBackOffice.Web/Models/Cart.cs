using EvoucherBackOffice.Web.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace EvoucherBackOffice.Web.Models
{
    public class Cart : ICart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
       
        public void AddItem(ExperienceViewModel experience, int quantity)
        {
            CartLine line = lineCollection
                            .Where(e => e.Experience.Code == experience.Code)
                            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Experience = experience, Quantity = quantity });
            }
            else
            {
                line.Quantity = quantity;
            }
        }

        public void RemoveItem(ExperienceViewModel experience, int quantity)
        {
            CartLine line = lineCollection
                           .Where(e => e.Experience.Code == experience.Code)
                           .FirstOrDefault();
            if (quantity==0)
            {
                lineCollection.RemoveAll(l => l.Experience.Code == experience.Code);
            }
            else
            {
                line.Quantity = quantity;
            }

        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Experience.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}
using EvoucherBackOffice.Web.ViewModel;
using System.Collections.Generic;

namespace EvoucherBackOffice.Web.Models
{
    public interface ICart
    {
        void AddItem(ExperienceViewModel experience, int quantity);
        void RemoveItem(ExperienceViewModel experience, int quantity);
        decimal ComputeTotalValue();
        void Clear();
        IEnumerable<CartLine> Lines { get; }
    }
}

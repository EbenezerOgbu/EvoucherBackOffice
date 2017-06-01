using EvoucherBackOffice.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Web.Models
{
    public interface ICart
    {
        void AddItem(ExperienceViewModel experience, int quantity);
        void AdjustQuantity(int newQuantity);
        decimal ComputeTotalValue();
        void Clear();
        CartLine Line { get; }
    }
}

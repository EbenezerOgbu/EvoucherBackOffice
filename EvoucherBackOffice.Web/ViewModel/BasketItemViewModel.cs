using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvoucherBackOffice.Web.ViewModel
{
    public class BasketItemViewModel
    {
        public int Quantity { get; set; }
        public ExperienceViewModel Experience { get; set; }
    }
}
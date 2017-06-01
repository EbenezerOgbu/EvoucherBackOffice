using EvoucherBackOffice.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvoucherBackOffice.Web.Models
{
    public class CartLine
    {
        public ExperienceViewModel Experience { get; set; }
        public int Quantity { get; set; }
    }
}
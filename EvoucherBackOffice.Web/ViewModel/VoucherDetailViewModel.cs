using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvoucherBackOffice.Web.ViewModel
{
    public class VoucherDetailViewModel
    {
        public string VoucherCode { get; set; }
        public string VoucherDescription { get; set; }
        public string Name { get; set; }
        public string VoucherPurchasedOn { get; set; }
        public string UsedOn { get; set; }
    }
}
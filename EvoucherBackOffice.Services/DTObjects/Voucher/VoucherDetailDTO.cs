using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services.DTObjects.Voucher
{
    public class VoucherDetailDTO
    {
        public string voucherCode { get; set; }
        public string voucherDescription { get; set; }
        public string name { get; set; }
        public string voucherPurchasedOn { get; set; }
        public string usedOn { get; set; }
    }
}

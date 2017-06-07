using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services.DTObjects.Voucher
{
    public class VoucherDetailDTO
    {
        //public string voucherId { get; set; }
        //public string token { get; set; }
        //public string vouchertypeId { get; set; }
        //public DateTime createdAt { get; set; }
        //public DateTime expiration { get; set; }
        //public string active { get; set; }
        //public int maxRedemptions { get; set; }
        //public int qtyRedeemed { get; set; }
        //public string userId { get; set; }
        //public string firstName { get; set; }
        //public string lastName { get; set; }
        //public string email { get; set; }

        public string voucherToken { get; set; }
        public string voucherDescription { get; set; }
        public string name { get; set; }
        public string voucherPurchasedOn { get; set; }
        public string usedOn { get; set; }
    }
}

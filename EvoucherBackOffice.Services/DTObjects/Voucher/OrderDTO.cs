using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services.DTObjects.Voucher
{
    public class OrderDTO
    {
        public string Code { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public CustomerDetailDTO CustomerDetail { get; set; }
    }
}

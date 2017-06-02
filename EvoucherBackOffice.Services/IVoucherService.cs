using EvoucherBackOffice.Services.DTObjects;
using EvoucherBackOffice.Services.DTObjects.Voucher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services
{
    public interface IVoucherService
    {
        Task ConfirmVoucher(ConfirmVoucherDTO confirmVoucher);
        Task RedeemVoucher(RedeemVoucherDTO redeemVoucher);
    }
}

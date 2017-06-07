using EvoucherBackOffice.Services.DTObjects;
using EvoucherBackOffice.Services.DTObjects.Voucher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services
{
    public interface IVoucherService
    {
        Task<VoucherDetailDTO> ConfirmVoucher(ConfirmVoucherDTO confirmVoucher);
        Task RedeemVoucher(RedeemVoucherDTO redeemVoucher);
        Task<VoucherDetailDTO> PostOrder(OrderDTO order);
    }
}

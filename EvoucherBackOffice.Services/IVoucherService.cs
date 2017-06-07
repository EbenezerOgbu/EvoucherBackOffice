using EvoucherBackOffice.Services.DTObjects.Voucher;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services
{
    public interface IVoucherService
    {
        Task<VoucherDetailDTO> GetVoucher(string token);
        Task<VoucherDetailDTO> RedeemVoucher(string token);
        Task<VoucherDetailDTO> CreateVoucher(CreateVoucherDTO createVoucher);
    }
}

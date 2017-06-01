using EvoucherBackOffice.Services.DTObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services
{
    public interface IVoucherService
    {
        Task<List<ExperienceDTO>> GetExperiences();
        Task PostOrder(OrderDTO order);
    }
}

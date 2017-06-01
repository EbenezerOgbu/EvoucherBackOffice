using EvoucherBackOffice.Services.DTObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services
{
    public interface IAccountService
    {
        Task<List<ExperienceDTO>> GetCategories();
        Task PostOrder(OrderDTO order);
    }
}

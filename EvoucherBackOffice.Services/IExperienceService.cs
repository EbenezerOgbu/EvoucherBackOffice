using EvoucherBackOffice.Services.DTObjects.Voucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services
{
    public interface IExperienceService
    {
        Task<List<ExperienceDTO>> GetExperiences();
    }
}

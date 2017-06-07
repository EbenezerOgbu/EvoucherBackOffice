using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services.DTObjects.Voucher
{
    public class CreateVoucherDTO
    {
        public CreateVoucherDTO()
        {
            attributes = new List<AttributeDTO>();
        }
        public string vouchertypeId { get; set; }
        public int maxRedemptions { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public List<AttributeDTO> attributes { get; set; }
    }
}

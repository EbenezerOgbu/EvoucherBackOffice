using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services.DTObjects.Voucher
{
    public class ExperienceDTO
    {
        public string code { get; set; }
        public string type { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string enabled { get; set; }
        public string group { get; set; }
        public string vat { get; set; }
        public decimal cost { get; set; }
        public string siteBasedCost { get; set; }
        public decimal price { get; set; }
        public string siteBasedPrice { get; set; }
        public string unit { get; set; }
        //public DateTime prepTime { get; set; }
        public string imageUrl { get; set; }
        public DateTime created { get; set; }
        public DateTime lastUpdate { get; set; }
    }
}

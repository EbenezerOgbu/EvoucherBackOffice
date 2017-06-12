using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvoucherBackOffice.Web.ViewModel
{
    public class ConfirmVoucherViewModel
    {
        [Required]
        public string VoucherToken { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvoucherBackOffice.Web.ViewModel
{
    public class BasketViewModel
    {
        [Display(Name = "QTY.")]
        [Range(1, 50, ErrorMessage = "Please enter a quantity between 1 and 50")]
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }
        public ExperienceViewModel Experience { get; set; }
        public CustomerDetailViewModel CustomerDetail { get; set; }
    }
}
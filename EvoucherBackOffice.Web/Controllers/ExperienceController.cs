using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IEvoucherClient _apiClient;
        public ExperienceController(IEvoucherClient apiClient)
        {
            _apiClient = apiClient;
        }
        public ActionResult Experiences()
        {
            var storedModel = (ExperiencesViewModel)HttpContext.Session["experiences"];
            if (storedModel != null)
            {
                AddImageUrl(storedModel);
                return View(storedModel);
            }
            var allCategories = _apiClient.GetCategories().Result;
            var model = new ExperiencesViewModel
            {
                Experiences = allCategories.Select(
                    c => new ExperienceViewModel
                    {
                        Code = c.code,
                        Type = c.type,
                        ShortDescription = c.shortDescription,
                        LongDescription = c.longDescription,
                        Vat = c.vat,
                        ImageUrl = c.imageUrl,
                        Price = c.price
                    }).ToList()
            };
            HttpContext.Session["experiences"] = model;

            AddCode(model);
            return View(model);
        }

        private static void AddCode(ExperiencesViewModel experiencesViewModel)
        {
            string[] urls =  { "11",
                               "22",
                               "33",
                               "44",
                               "55",
                               "66"
                             };

            var index = 0;
            foreach (var exp in experiencesViewModel.Experiences)
            {
                exp.Code = urls[index];
                index++;
            }
        }
    }
}
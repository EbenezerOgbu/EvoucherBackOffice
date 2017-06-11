using EvoucherBackOffice.Services;
using EvoucherBackOffice.Web.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        public ActionResult Experiences()
        {
            var storedModel = (ExperiencesViewModel)HttpContext.Session["experiences"];
            if (storedModel != null)
            {
                return View(storedModel);
            }
            try
            {
                var allExperiences = _experienceService.GetExperiences().Result;
                var model = new ExperiencesViewModel
                {
                    BasketItems = allExperiences.Select(
                        c => new BasketItemViewModel
                        {
                            Experience = new ExperienceViewModel
                            {
                                Code = c.code,
                                Type = c.type,
                                ShortDescription = c.shortDescription,
                                LongDescription = c.longDescription,
                                Vat = c.vat,
                                ImageUrl = c.imageUrl,
                                Price = c.price
                            }

                        }).ToList()
                };

                HttpContext.Session["experiences"] = model;

                AddCode(model);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }         
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
            foreach (var bas in experiencesViewModel.BasketItems)
            {
                bas.Experience.Code = urls[index];
                index++;
            }
        }
    }
}
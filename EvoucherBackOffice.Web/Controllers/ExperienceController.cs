using EvoucherBackOffice.Services;
using EvoucherBackOffice.Web.ViewModel;
using System;
using System.Collections.Generic;
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
                //var allExperiences = _experienceService.GetExperiences().Result;
                //var model = new ExperiencesViewModel
                //{
                //    Experiences = allExperiences.Select(
                //    c => new ExperienceViewModel
                //    {
                //        Code = c.code,
                //        Type = c.type,
                //        ShortDescription = c.shortDescription,
                //        LongDescription = c.longDescription,
                //        Vat = c.vat,
                //        ImageUrl = c.imageUrl,
                //        Price = c.price
                //    }).ToList()
                //};

                var model = CreateExperiences();

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
            foreach (var bas in experiencesViewModel.Experiences)
            {
                bas.Code = urls[index];
                index++;
            }
        }

        private ExperiencesViewModel CreateExperiences()
        {
            var list = new List<ExperienceViewModel>
            {
                new ExperienceViewModel
                {
                    ShortDescription = "1 Day Luxury package",
                    Price = 95
                },
                new ExperienceViewModel
                {
                   ShortDescription = "3 Day VIP Dinning",
                   Price = 150
                },
                new ExperienceViewModel
                {
                    ShortDescription = "1 Month total lounge",
                    Price = 400
                },
                new ExperienceViewModel
                {
                     ShortDescription = "1 week access",
                     Price = 295
                },
                 new ExperienceViewModel
                {
                   ShortDescription = "1 month lounge access",
                   Price = 495
                },
                new ExperienceViewModel
                {
                    ShortDescription = "1 year access",
                    Price = 750
                }
            };
            var experiencesViewModel = new ExperiencesViewModel
            {
                Experiences = list
            };
            return experiencesViewModel;
        }

    }
}
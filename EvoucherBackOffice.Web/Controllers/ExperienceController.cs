using EvoucherBackOffice.Services;
using EvoucherBackOffice.Web.ViewModel;
using System;
using System.Collections.Generic;
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
                //    BasketItems = allExperiences.Select(
                //        c => new BasketItemViewModel
                //        {
                //            Experience = new ExperienceViewModel
                //            {
                //                Code = c.code,
                //                Type = c.type,
                //                ShortDescription = c.shortDescription,
                //                LongDescription = c.longDescription,
                //                Vat = c.vat,
                //                ImageUrl = c.imageUrl,
                //                Price = c.price
                //            }

                //        }).ToList()
                //};

                var model = CreateBasketItems();
                HttpContext.Session["experiences"] = model;

                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }         
        }

        private ExperiencesViewModel CreateBasketItems()
        {
            var list = new List<BasketItemViewModel>
            {
                new BasketItemViewModel
                {
                    Quantity = 0,
                    Experience = new ExperienceViewModel
                    {
                        ShortDescription = "1 Day Luxury package",
                        Price = 95
                    }
                },
                new BasketItemViewModel
                {
                    Quantity = 0,
                    Experience = new ExperienceViewModel
                    {
                        ShortDescription = "3 Day VIP Dinning",
                        Price = 150
                    }
                },
                new BasketItemViewModel
                {
                    Quantity = 0,
                    Experience = new ExperienceViewModel
                    {
                        ShortDescription = "1 Month total lounge",
                        Price = 400
                    }
                },
                new BasketItemViewModel
                {
                    Quantity = 0,
                    Experience = new ExperienceViewModel
                    {
                        ShortDescription = "1 week access",
                        Price = 295
                    }
                },
                 new BasketItemViewModel
                {
                    Quantity = 0,
                    Experience = new ExperienceViewModel
                    {
                        ShortDescription = "1 month lounge access",
                        Price = 495
                    }
                },
                new BasketItemViewModel
                {
                    Quantity = 0,
                    Experience = new ExperienceViewModel
                    {
                        ShortDescription = "1 year access",
                        Price = 750
                    }
                }
            };
            var experiencesViewModel = new ExperiencesViewModel
            {
                BasketItems = list
            };
            return experiencesViewModel;
        }
    }
}
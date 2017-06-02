using EvoucherBackOffice.Services;
using EvoucherBackOffice.Web.ViewModel;
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

                return View(model);
            }
            catch (System.Exception)
            {

                throw;
            }         
        }
    }
}
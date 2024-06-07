using ALaRechercheDesAnimaux.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ALaRechercheDesAnimaux.Models.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;



namespace ALaRechercheDesAnimaux.Controllers.Edition
{
    public class EditionController : Controller
    {
        private ICatalogue catalogue; 
        public EditionController(ICatalogue catalogueEspeces) 
        { 
            catalogue = catalogueEspeces;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Creation()
        {
			return View();
		}

		

		[HttpPost]
        public IActionResult Creation(EditionViewModel detail)
        {
            if (ModelState.IsValid)
            {
				int id = catalogue.Sauvegarde(detail);
				return RedirectToAction("DetailEdition", new { id });
			}
            else
            {
                return View();
            }


        }
        [HttpGet]
        public IActionResult DetailEdition(int id)
        {
            var observation = catalogue.GetEditionById(id);
            return View(observation);
        }
    }
}

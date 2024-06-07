using ALaRechercheDesAnimaux.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ALaRechercheDesAnimaux.Controllers.Especes
{
    public class EspecesController : Controller
    {
        public IActionResult Index()
        {
            return Content("formulaire de recherche");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Create(string NomScientique)
        {
            return RedirectToAction("Detail", new { NomScientique });

        }
        public IActionResult Detail(int? id, string? NomSci)
        {
            if (NomSci != null)
            {
                var animal1 = new DetailViewModel("Vulpes vulpes", "Renard", "Terre", "Lien vers le site de INPN");

                return View(animal1);
            }
            else if (id == null)
            {
                return BadRequest();

            }
            else
            {
                return Content("Les details de l'espèce identifié par " + id);
            }
        }

        public IActionResult List()
        {
            List<DetailViewModel> ListeAnimaux = new List<DetailViewModel>();
            DetailViewModel Renard = new DetailViewModel { NomScientifique = "Vulpes vulpes", NomCommun = "Renard", Habitat = "Terre", Url = "Lien vers le site de INPN", };
            ListeAnimaux.Add(Renard);

            DetailViewModel Ours = new DetailViewModel { NomScientifique = "Ourtitus", NomCommun = "Ours", Habitat = "Terre", Url = "Lien vers le site de INPN", };
            ListeAnimaux.Add(Renard);

            DetailViewModel Dolphin = new DetailViewModel { NomScientifique = "Dolphidite", NomCommun = "Dolphin", Habitat = "Ocean", Url = "Lien vers le site de INPN", };
            ListeAnimaux.Add(Renard);


            return View(ListeAnimaux);
        }

        public IActionResult Tags(string tag)
        {
            if (tag == "tag1")
            {
                return Content("Voilà une liste des espèces possédant le tag");
            }
            else
            {
                return Content("Voilà rien");
            }

        }

    }
}

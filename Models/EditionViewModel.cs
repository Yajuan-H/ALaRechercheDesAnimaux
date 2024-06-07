using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace ALaRechercheDesAnimaux.Models
{
	public class EditionViewModel
	{
		[StringLength(20, ErrorMessage = "The length can't be more than 20.")]
		public string EspecesObservees { get; set; }
		[DataType(DataType.Date)]
        public DateTime Date { get; set; }

		public string? Commune { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
		public string? Nom { get; set; }

		[Range(1, 10)]
		public int Nombre { get; set; }

		[StringLength(40, ErrorMessage = "The length can't be more than 40.")]
		public string? Commentaires { get; set; }

		


	public EditionViewModel()
        {
        }

        public EditionViewModel(string especesObservees, DateTime date, string commune, string email, string nom, int nombre, string commentaires)
		{
			EspecesObservees = especesObservees;
			Date = date;
			Commune = commune;
			Email = email;
			Nom = nom;
			Nombre = nombre;
			Commentaires = commentaires;
		}
		
		
	}
}

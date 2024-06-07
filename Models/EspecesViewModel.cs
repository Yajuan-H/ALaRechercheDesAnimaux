namespace ALaRechercheDesAnimaux.Models
{
    public class EspecesViewModel
    {
        public string NomScientique { get; set; }

		public EspecesViewModel(string nomScientique)
		{
			NomScientique = nomScientique;
		}
	}
}

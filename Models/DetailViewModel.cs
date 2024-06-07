namespace ALaRechercheDesAnimaux.Models
{
    public class DetailViewModel
    {
        public string NomScientifique { get; set; }

       
        public string NomCommun { get; set; }
		
		public string Habitat { get; set; }
		
		public string Url { get; set; }

        public DetailViewModel()
        {
        }

        public DetailViewModel(string nomScientifique, string nomCommun, string habitat, string url)
		{
			NomScientifique = nomScientifique;
			NomCommun = nomCommun;
			Habitat = habitat;
			Url = url;
		}
	}
}

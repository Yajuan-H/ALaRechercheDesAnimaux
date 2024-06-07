namespace ALaRechercheDesAnimaux.Models.Services
{
    public class FakeCatalogueEspeces : ICatalogue
    {
        private Dictionary<int, EditionViewModel> catalogue = new Dictionary<int, EditionViewModel>();
        private int counter = 67;

        public int Sauvegarde(EditionViewModel vm)
        {
            int id = counter++;
            catalogue.Add(id, vm);
            return id;
        }

        public EditionViewModel GetEditionById(int id)
        {
            if (catalogue.TryGetValue(id, out EditionViewModel result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}

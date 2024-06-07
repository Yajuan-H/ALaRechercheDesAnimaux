using ALaRechercheDesAnimaux.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ALaRechercheDesAnimaux.Models.Services
{
    public interface ICatalogue
    {
        int Sauvegarde(EditionViewModel model);

        EditionViewModel GetEditionById(int id);

    }

    public class EntityCatalogue : ICatalogue
    {
        private readonly Especes3Context context;

        public EntityCatalogue(Especes3Context context)
        {
            this.context = context;
        }

        public IEnumerable<string> RecherchesTags(string query)
        {
            return context.Tags
                    .Where(t => t.Nom.StartsWith(query))
                    .Select(t => t.Nom)
                    .ToList();
        }

        public Espece? RechercherParId(int id)
        {
            return context.Especes.Find(id);
        }

        public int Sauvegarde(EditionViewModel model)
        {
            throw new NotImplementedException();
        }

        public EditionViewModel GetEditionById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

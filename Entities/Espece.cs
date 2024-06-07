using System;
using System.Collections.Generic;

namespace ALaRechercheDesAnimaux.Entities;

public partial class Espece
{
    public int EspeceId { get; set; }

    public string NomScientifique { get; set; } = null!;

    public int PresenceEnMetropole { get; set; }

    public int Habitat { get; set; }

    public int IdInpn { get; set; }

    public virtual ICollection<Observation> Observations { get; set; } = new List<Observation>();

    public virtual ICollection<Tag> TagsTags { get; set; } = new List<Tag>();
}

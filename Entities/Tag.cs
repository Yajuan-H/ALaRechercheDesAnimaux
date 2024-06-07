using System;
using System.Collections.Generic;

namespace ALaRechercheDesAnimaux.Entities;

public partial class Tag
{
    public int TagId { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<Espece> EspecesEspeces { get; set; } = new List<Espece>();
}

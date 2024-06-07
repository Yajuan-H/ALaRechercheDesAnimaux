using System;
using System.Collections.Generic;

namespace ALaRechercheDesAnimaux.Entities;

public partial class Observation
{
    public int ObservationId { get; set; }

    public DateTime PostedAt { get; set; }

    public DateTime ObservedAt { get; set; }

    public string EmailObservateur { get; set; } = null!;

    public int? Individus { get; set; }

    public string NomCommune { get; set; } = null!;

    public string? Commentaires { get; set; }

    public int EspeceObserveeEspeceId { get; set; }

    public virtual Espece EspeceObserveeEspece { get; set; } = null!;
}

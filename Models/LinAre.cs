using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

/// <summary>
/// ntermediario entre linea y area
/// </summary>
public partial class LinAre
{
    /// <summary>
    /// Identificador
    /// </summary>
    public int IdLinAre { get; set; }

    /// <summary>
    /// Codigo de la linea con area
    /// </summary>
    public int IdLinea { get; set; }

    public int IdArea { get; set; }

    /// <summary>
    /// Codigo de la linea con area
    /// </summary>
    public string? Lacodigo { get; set; }

    public virtual ICollection<AudCa> AudCas { get; } = new List<AudCa>();

    public virtual Area IdAreaNavigation { get; set; } = null!;

    public virtual Linea IdLineaNavigation { get; set; } = null!;

    public virtual ICollection<ParAre> ParAres { get; } = new List<ParAre>();

    public virtual ICollection<ParsiOee> ParsiOees { get; } = new List<ParsiOee>();
}

using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

/// <summary>
/// cargos registrados en las reuniones de las paradas por mantenimiento
/// </summary>
public partial class CargoPm
{
    /// <summary>
    /// identificador
    /// </summary>
    public int IdCargoPm { get; set; }

    /// <summary>
    /// cargo del asistidor
    /// </summary>
    public string? Cpmnom { get; set; }

    public virtual ICollection<AsisPm> AsisPms { get; } = new List<AsisPm>();
}

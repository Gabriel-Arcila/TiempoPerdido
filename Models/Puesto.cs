using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

public partial class Puesto
{
    public int IdPuesto { get; set; }

    public string? PuCodigo { get; set; }

    public string? PuDescri { get; set; }

    public bool? PuEstado { get; set; }

    public virtual ICollection<Personal> Personals { get; } = new List<Personal>();
}

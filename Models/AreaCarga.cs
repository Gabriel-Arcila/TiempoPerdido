using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

public partial class AreaCarga
{
    public int IdAreaCarg { get; set; }

    public string Acnombre { get; set; } = null!;

    public string? Acdetalle { get; set; }

    public bool Acestado { get; set; }

    public virtual ICollection<LibroNove> LibroNoves { get; } = new List<LibroNove>();
}

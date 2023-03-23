using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

public partial class ClasifiTpm
{
    public int IdCtpm { get; set; }

    public string Ctpmnom { get; set; } = null!;

    public bool Ctpmestado { get; set; }

    public virtual ICollection<LibroNove> LibroNoves { get; } = new List<LibroNove>();
}

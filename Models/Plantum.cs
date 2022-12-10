using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

public partial class Plantum
{
    public int IdPlanta { get; set; }

    public string? PlCodigo { get; set; }

    public string? PlDescri { get; set; }

    public bool? PlEstado { get; set; }

    public virtual ICollection<AreaTra> AreaTras { get; } = new List<AreaTra>();
}

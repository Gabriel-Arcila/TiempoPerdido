using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

public partial class CortCate
{
    public int IdCortCate { get; set; }

    public string Ccnombre { get; set; } = null!;

    public string? Ccdesc { get; set; }

    public string? Cccodigo { get; set; }

    public virtual ICollection<CorteDi> CorteDis { get; } = new List<CorteDi>();
}

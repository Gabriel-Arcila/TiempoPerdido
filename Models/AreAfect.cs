using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

public partial class AreAfect
{
    public int IdAreAfect { get; set; }

    public string Aanom { get; set; } = null!;

    public bool Aaestado { get; set; }

    public string? Aadetalle { get; set; }

    public virtual ICollection<TieParTp> TieParTps { get; } = new List<TieParTp>();
}

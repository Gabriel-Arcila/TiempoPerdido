using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

public partial class Ksf
{
    public int Idksf { get; set; }

    public string KsfNombre { get; set; } = null!;

    public bool KsfEsta { get; set; }
}

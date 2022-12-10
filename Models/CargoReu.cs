using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

public partial class CargoReu
{
    public int IdCargoR { get; set; }

    public string Crnombre { get; set; } = null!;

    public bool Cresta { get; set; }

    public string Crempresa { get; set; } = null!;

    public string? Cearea { get; set; }

    public virtual ICollection<AsistenReu> AsistenReus { get; } = new List<AsistenReu>();
}

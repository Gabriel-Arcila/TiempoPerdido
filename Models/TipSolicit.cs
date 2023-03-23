using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

public partial class TipSolicit
{
    public int IdTipSol { get; set; }

    public string Tsnombre { get; set; } = null!;

    public virtual ICollection<ProMejCont> ProMejConts { get; } = new List<ProMejCont>();
}

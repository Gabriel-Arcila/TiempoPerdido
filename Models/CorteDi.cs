using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

public partial class CorteDi
{
    public int IdCortDisc { get; set; }

    public string? CdcodProd { get; set; }

    public string? Cdequipo { get; set; }

    public string? Cdvariable { get; set; }

    public string? Cdexpres { get; set; }

    public double? Cdmuestra { get; set; }

    public double? Cdmin { get; set; }

    public double? Cdmax { get; set; }

    public int IdCortCate { get; set; }

    public DateTime Cdfecha { get; set; }

    public string? CdplanAcc { get; set; }

    public double? Cdnuevo { get; set; }

    public bool? Cdresuelto { get; set; }

    public virtual CortCate IdCortCateNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models;

/// <summary>
/// Productos
/// </summary>
public partial class Producto
{
    /// <summary>
    /// identificador
    /// </summary>
    public int IdProducto { get; set; }

    /// <summary>
    /// Codigo del producto
    /// </summary>
    public string? Pcodigo { get; set; }

    /// <summary>
    /// nombre de la parte
    /// </summary>
    public string Pnombre { get; set; } = null!;

    /// <summary>
    /// detalle de la parte
    /// </summary>
    public string? Pdetalle { get; set; }

    /// <summary>
    /// 0: Inactivo, 1:Activo
    /// </summary>
    public bool Pestado { get; set; }

    public virtual ICollection<LinPro> LinPros { get; } = new List<LinPro>();

    public virtual ICollection<TurPro> TurPros { get; } = new List<TurPro>();
}

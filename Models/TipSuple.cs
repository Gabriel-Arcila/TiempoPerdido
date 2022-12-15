using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models
{
    public partial class TipSuple
    {
        public TipSuple()
        {
            Resumen = new HashSet<Resuman>();
        }

        public int IdTipSuple { get; set; }
        public string? Tscodigo { get; set; }
        public string? Tsdescri { get; set; }
        public bool? Tsestado { get; set; }

        public virtual ICollection<Resuman> Resumen { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models
{
    /// <summary>
    /// ntermediario entre linea y area
    /// </summary>
    public partial class LinAre
    {
        public LinAre()
        {
            AudCas = new HashSet<AudCa>();
            ParAres = new HashSet<ParAre>();
            ParsiOees = new HashSet<ParsiOee>();
            TieParTps = new HashSet<TieParTp>();
        }

        /// <summary>
        /// Identificador
        /// </summary>
        public int IdLinAre { get; set; }
        /// <summary>
        /// Codigo de la linea con area
        /// </summary>
        public int IdLinea { get; set; }
        public int IdArea { get; set; }
        /// <summary>
        /// Codigo de la linea con area
        /// </summary>
        public string? Lacodigo { get; set; }

        public virtual Area IdAreaNavigation { get; set; } = null!;
        public virtual Linea IdLineaNavigation { get; set; } = null!;
        public virtual ICollection<AudCa> AudCas { get; set; }
        public virtual ICollection<ParAre> ParAres { get; set; }
        public virtual ICollection<ParsiOee> ParsiOees { get; set; }
        public virtual ICollection<TieParTp> TieParTps { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace TiempoPerdido.Models
{
    public partial class UsuariosPermiso
    {
        public int IdUsuario { get; set; }
        public string UsNombre { get; set; } = null!;
        public string UsApellido { get; set; } = null!;
        public string? UsUsuario { get; set; }
        public string UsFicha { get; set; } = null!;
        public string Proyecto { get; set; } = null!;
        public string? Division { get; set; }
        public string Centro { get; set; } = null!;
        public string Rol { get; set; } = null!;
    }
}

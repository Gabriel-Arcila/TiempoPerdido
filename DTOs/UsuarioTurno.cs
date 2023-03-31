using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TiempoPerdido.Validate;

namespace TiempoPerdido.DTOs
{
    public class UsuarioTurno
    {
        [Required(ErrorMessage ="Coloque la ficha.")]
        public string ficha {get; set;}
        [ValidDiferenteACero]
        public int idLinea {get; set;}
        [ValidDiferenteACero]
        public string productos {get; set;}

    }
}
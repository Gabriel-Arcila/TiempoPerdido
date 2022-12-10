using TiempoPerdido.Models;


namespace TiempoPerdido.Service
{
    public class UsuarioServices{
        public event Action? Onchange;

        public Usuario? usuario { get; set; }
        public  Dictionary<string,int>? permisos { get; set; }
        public bool login { get; set; }

        public void set(Usuario usuario, Dictionary<string,int>  permisos){
            this.usuario = usuario;
            this.permisos = permisos;
            this.login = true;
            Onchange?.Invoke();
        }

        public void logout(){
            this.usuario = new Usuario();
            this.permisos = new Dictionary<string,int>();
            this.login = false;
            Onchange?.Invoke();
        }
        // public async Task setNull(){
        //     this.usuario = usuario;
        //     Onchange?.Invoke();
        // }
    }
}
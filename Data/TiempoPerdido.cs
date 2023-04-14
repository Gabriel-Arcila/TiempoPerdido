using TiempoPerdido.Models;
using Microsoft.EntityFrameworkCore;

namespace  TiempoPerdido.Data
{
    public interface IDataTieEjeTp
    { 
        // Task<List<TieEjeTp>> ObtenerParadas(int idLinea);
    }

    public class DataTieEjeTp : IDataTieEjeTp
    {
        private readonly DbNeoContext _cotext;

        public DataTieEjeTp(DbNeoContext context)
        {
            this._cotext = context;
        }
        // public async Task<List<TieEjeTp>> ObtenerParadas(int idLinea)
        // {
        //     return await this._cotext.TieEjeTps.Include(t => t.IdParsiOeeNavigation).ThenInclude(o => o.IdTurnoTpNavigation).Where(t => t.IdParsiOeeNavigation.IdTurnoTpNavigation.IdLinea == idLinea && t.IdParsiOeeNavigation.IdTurnoTpNavigation.Tfecha >= DateTime.Now).ToListAsync();
        // }
    }

    public interface IDataTieParTp
    { 
        Task<List<TieParTp>> ObtenerParadas(int IdTurnoTp);
    }

    public class DataTieParTp : IDataTieParTp
    {
        private readonly DbNeoContext _cotext;

        public DataTieParTp(DbNeoContext context)
        {
            this._cotext = context;
        }
        public async Task<List<TieParTp>> ObtenerParadas(int IdTurnoTp)
        {
            return await this._cotext.TieParTps.Where(t => t.IdParsiOeeNavigation.IdTurnoTp == IdTurnoTp).Include(t => t.IdAreAfectNavigation).Include(t => t.IdParaTpNavigation).ThenInclude(p => p.IdTiParTpNavigation).Include(t => t.IdParsiOeeNavigation).ThenInclude(P => P.IdAreaNavigation).ThenInclude(a => a.IdAreaNavigation).ToListAsync();
        }
    }

    public interface IDataOperador
    { 
        Task<Operador> BuscarOperador(string ficha);
    }

    public class DataOperador : IDataOperador
    {
        private readonly DbNeoContext _cotext;

        public DataOperador(DbNeoContext context)
        {
            this._cotext = context;
        }
        public async Task<Operador> BuscarOperador(string ficha)
        {
            return await this._cotext.Operadors.Where(o => o.Opficha == ficha).FirstOrDefaultAsync();
        }
    }

    public interface IDataTurnoTp
    { 
        Task<TurnoTp?> TurnoActual(int idLinea);
        Task<bool> ActulizarTurno(TurnoTp turno);
    }
    public class DataTurnoTp : IDataTurnoTp
    {
        private readonly DbNeoContext _cotext;

        public DataTurnoTp(DbNeoContext context)
        {
            this._cotext = context;
        }
        public async Task<TurnoTp?> TurnoActual(int idLinea)
        {
            ParsiOee pasiOEE;
            string turno = "";
            DateTime fechaActual = DateTime.Now;
            if(fechaActual.Hour >= 6 && fechaActual.Hour < 18){
                turno = "1";
            }else{
                turno = "2";
            }
            pasiOEE =  await this._cotext.ParsiOees.Include(t => t.IdTurnoTpNavigation).Include(t => t.IdAreaNavigation).Where(p => (p.IdTurnoTpNavigation.Tfecha.Date == fechaActual.Date) && (p.IdTurnoTpNavigation.Tturno == turno) && (p.IdAreaNavigation.IdLinea == idLinea)).FirstOrDefaultAsync();
            return pasiOEE.IdTurnoTpNavigation;
        }
        public async Task<bool> ActulizarTurno(TurnoTp turno)
        {
            TurnoTp actulizacion = await this._cotext.TurnoTps.Where(t => t.IdTurnoTp == turno.IdTurnoTp).FirstOrDefaultAsync();
            if(actulizacion != null){
                actulizacion.ToperaFich = turno.ToperaFich;
                actulizacion.Tturno = turno.Tturno;
                actulizacion.Tfecha = turno.Tfecha;
                actulizacion.TcodiProdu = turno.TcodiProdu;
                actulizacion.Ttrabajado = turno.Ttrabajado;
                actulizacion.Tperdido = turno.Tperdido;
                actulizacion.Tpbueno = turno.Tpbueno;
                actulizacion.Tpmalo = turno.Tpmalo;
                actulizacion.Tvelocidad = turno.Tvelocidad;
                actulizacion.Trendi = turno.Trendi;
                actulizacion.Tcalidad = turno.Tcalidad;
                actulizacion.Tdispo = turno.Tdispo;
                actulizacion.Toee = turno.Toee;
                return await this._cotext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
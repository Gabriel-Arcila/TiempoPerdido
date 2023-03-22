using TiempoPerdido.Models;
using Microsoft.EntityFrameworkCore;

namespace  TiempoPerdido.Data
{
    public interface IDataTieEjeTp
    { 
        Task<List<TieEjeTp>> ObtenerParadas(int idLinea);
    }

    public class DataTieEjeTp : IDataTieEjeTp
    {
        private readonly DbNeoContext _cotext;

        public DataTieEjeTp(DbNeoContext context)
        {
            this._cotext = context;
        }
        public async Task<List<TieEjeTp>> ObtenerParadas(int idLinea)
        {
            return await this._cotext.TieEjeTps.Include(t => t.IdParsiOeeNavigation).ThenInclude(o => o.IdTurnoTpNavigation).Where(t => t.IdParsiOeeNavigation.IdTurnoTpNavigation.IdLinea == idLinea && t.IdParsiOeeNavigation.IdTurnoTpNavigation.Tfecha >= DateTime.Now).ToListAsync();
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
        Task<TurnoTp> TurnoActual(int idLinea);
        Task<bool> ActulizarTurno(TurnoTp turno);
    }
    public class DataTurnoTp : IDataTurnoTp
    {
        private readonly DbNeoContext _cotext;

        public DataTurnoTp(DbNeoContext context)
        {
            this._cotext = context;
        }
        public async Task<TurnoTp> TurnoActual(int idLinea)
        {
            string turno = "";
            DateTime fechaActual = DateTime.Now;
            if(fechaActual.Hour >= 6 && fechaActual.Hour < 18){
                turno = "1";
            }else if(fechaActual.Hour >= 18 && fechaActual.Hour <= 24){
                turno = "2";
            }else if(fechaActual.Hour >= 0 && fechaActual.Hour < 6){
                turno = "2";
                fechaActual = DateTime.Now.AddDays(-1);
            }
            return await this._cotext.TurnoTps.Where(t => (t.Tfecha.Date == fechaActual.Date) && (t.Tturno == turno) && (t.IdLinea == idLinea) ).FirstOrDefaultAsync();
        }
         public async Task<bool> ActulizarTurno(TurnoTp turno)
        {
            TurnoTp actulizacion = await this._cotext.TurnoTps.Where(t => t.IdTurnoTp == turno.IdTurnoTp).FirstOrDefaultAsync();
            if(actulizacion != null){
                actulizacion.IdOperador = turno.IdOperador;
                return await this._cotext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
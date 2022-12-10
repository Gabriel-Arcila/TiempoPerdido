using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TiempoPerdido.Models;

public partial class DbNeoContext : DbContext
{
    public DbNeoContext()
    {
    }

    public DbNeoContext(DbContextOptions<DbNeoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<AreaTra> AreaTras { get; set; }

    public virtual DbSet<AsisPm> AsisPms { get; set; }

    public virtual DbSet<AsistenReu> AsistenReus { get; set; }

    public virtual DbSet<AudCa> AudCas { get; set; }

    public virtual DbSet<AutenUsr> AutenUsrs { get; set; }

    public virtual DbSet<CargoPm> CargoPms { get; set; }

    public virtual DbSet<CargoReu> CargoReus { get; set; }

    public virtual DbSet<Centro> Centros { get; set; }

    public virtual DbSet<ClasifiTpm> ClasifiTpms { get; set; }

    public virtual DbSet<ClienteP> ClientePs { get; set; }

    public virtual DbSet<DatAudCa> DatAudCas { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<IdAreaConLinea> IdAreaConLineas { get; set; }

    public virtual DbSet<Ksf> Ksfs { get; set; }

    public virtual DbSet<LibroNove> LibroNoves { get; set; }

    public virtual DbSet<LinAre> LinAres { get; set; }

    public virtual DbSet<LinPro> LinPros { get; set; }

    public virtual DbSet<Linea> Lineas { get; set; }

    public virtual DbSet<Nivel> Nivels { get; set; }

    public virtual DbSet<NovedadesActualesChempro> NovedadesActualesChempros { get; set; }

    public virtual DbSet<Operador> Operadors { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<ParAre> ParAres { get; set; }

    public virtual DbSet<ParaTp> ParaTps { get; set; }

    public virtual DbSet<ParsiOee> ParsiOees { get; set; }

    public virtual DbSet<Parte> Partes { get; set; }

    public virtual DbSet<ParteLineaAreaCentro> ParteLineaAreaCentros { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Plantum> Planta { get; set; }

    public virtual DbSet<PregP> PregPs { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<ProyectoUsr> ProyectoUsrs { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<RespP> RespPs { get; set; }

    public virtual DbSet<RespoReu> RespoReus { get; set; }

    public virtual DbSet<Resuman> Resumen { get; set; }

    public virtual DbSet<ReuParM> ReuParMs { get; set; }

    public virtual DbSet<ReunionDium> ReunionDia { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RspnsblP> RspnsblPs { get; set; }

    public virtual DbSet<TecniCa> TecniCas { get; set; }

    public virtual DbSet<TiPaPar> TiPaPars { get; set; }

    public virtual DbSet<TiParTp> TiParTps { get; set; }

    public virtual DbSet<TieEjeTp> TieEjeTps { get; set; }

    public virtual DbSet<TieParTp> TieParTps { get; set; }

    public virtual DbSet<TipSuple> TipSuples { get; set; }

    public virtual DbSet<TurPro> TurPros { get; set; }

    public virtual DbSet<TurnoTp> TurnoTps { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuariosPermiso> UsuariosPermisos { get; set; }

    public virtual DbSet<VarAre> VarAres { get; set; }

    public virtual DbSet<VarCa> VarCas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AZTDTDB03\\DESARROLLO;Database=DbNeo;TrustServerCertificate=True;Persist Security Info=True;User ID=UsrEncuesta;Password=Enc2022**Ing");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdArea);

            entity.ToTable("Area", tb => tb.HasComment("Area de produccion"));

            entity.Property(e => e.IdArea).HasComment("identificador del area");
            entity.Property(e => e.Adetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("Detalle del area")
                .HasColumnName("ADetalle");
            entity.Property(e => e.Aestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("AEstado");
            entity.Property(e => e.Anom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("nombre del area")
                .HasColumnName("ANom");
        });

        modelBuilder.Entity<AreaTra>(entity =>
        {
            entity.HasKey(e => e.IdAreaTra).HasName("PK__AreaTra__487F56B804138E4C");

            entity.ToTable("AreaTra");

            entity.Property(e => e.AtcodBpc).HasColumnName("ATCodBPC");
            entity.Property(e => e.Atcodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ATCodigo");
            entity.Property(e => e.Atestado).HasColumnName("ATEstado");
            entity.Property(e => e.Atnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ATNombre");

            entity.HasOne(d => d.IdPlantaNavigation).WithMany(p => p.AreaTras)
                .HasForeignKey(d => d.IdPlanta)
                .HasConstraintName("FK__AreaTra__IdPlant__5D2BD0E6");
        });

        modelBuilder.Entity<AsisPm>(entity =>
        {
            entity.HasKey(e => e.IdAsisPm);

            entity.ToTable("AsisPM", tb => tb.HasComment("reuniones de paradas por mantenimiento"));

            entity.Property(e => e.IdAsisPm)
                .HasComment("identificador")
                .HasColumnName("IdAsisPM");
            entity.Property(e => e.AisAsis)
                .HasComment("1: Asistencia, 0: Inasistencia")
                .HasColumnName("AIsAsis");
            entity.Property(e => e.IdCargoPm)
                .HasComment("identificador  CargoPM")
                .HasColumnName("IdCargoPM");
            entity.Property(e => e.IdReuParM).HasComment("identificador ReuParM");

            entity.HasOne(d => d.IdCargoPmNavigation).WithMany(p => p.AsisPms)
                .HasForeignKey(d => d.IdCargoPm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AsisPM_CargoPM");

            entity.HasOne(d => d.IdReuParMNavigation).WithMany(p => p.AsisPms)
                .HasForeignKey(d => d.IdReuParM)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AsisPM_ReuParM");
        });

        modelBuilder.Entity<AsistenReu>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia);

            entity.ToTable("AsistenReu");

            entity.Property(e => e.ArObser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ararea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ARArea");
            entity.Property(e => e.Arfecha)
                .HasColumnType("date")
                .HasColumnName("ARFecha");
            entity.Property(e => e.AridCargoR).HasColumnName("ARIdCargoR");

            entity.HasOne(d => d.AridCargoRNavigation).WithMany(p => p.AsistenReus)
                .HasForeignKey(d => d.AridCargoR)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AsistenReu_CargoReu");
        });

        modelBuilder.Entity<AudCa>(entity =>
        {
            entity.HasKey(e => e.IdAudCa);

            entity.ToTable("AudCa", "his", tb => tb.HasComment("historico de auditorias de calidad"));

            entity.Property(e => e.IdAudCa).HasComment("Identificador de la auditoria de calidad");
            entity.Property(e => e.AccodiPro)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("codigo del producto")
                .HasColumnName("ACCodiPro");
            entity.Property(e => e.Acfecha)
                .HasComment("fecha de la auditoria")
                .HasColumnType("datetime")
                .HasColumnName("ACFecha");
            entity.Property(e => e.AcficOper)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("ficha del operador")
                .HasColumnName("ACFicOper");
            entity.Property(e => e.AcficSuper)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("ficha del supervisor")
                .HasColumnName("ACFicSuper");
            entity.Property(e => e.Acgrupo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("grupo de la auditoria")
                .HasColumnName("ACGrupo");
            entity.Property(e => e.AcisCamPro)
                .HasComment("0: No es un cambio de producto; 1: cambio de producto")
                .HasColumnName("ACisCamPro");
            entity.Property(e => e.AcisTecn)
                .HasComment("0: auditoria operador, 1: tecnico de calidad")
                .HasColumnName("ACisTecn");
            entity.Property(e => e.Aclote)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("lote del producto")
                .HasColumnName("ACLote");
            entity.Property(e => e.Acobserv)
                .IsUnicode(false)
                .HasComment("observaciones dispuestas en la auditoria")
                .HasColumnName("ACObserv");
            entity.Property(e => e.Acpresentacion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("presentacion del producto")
                .HasColumnName("ACPresentacion");
            entity.Property(e => e.Acturno)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("turno de la aditoria")
                .HasColumnName("ACTurno");
            entity.Property(e => e.IdArea).HasComment("identificador del area");
            entity.Property(e => e.IdTecniCa).HasComment("identificador del tecnico");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.AudCas)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AudCa_LinAre");

            entity.HasOne(d => d.IdTecniCaNavigation).WithMany(p => p.AudCas)
                .HasForeignKey(d => d.IdTecniCa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AudCa_TecniCa");
        });

        modelBuilder.Entity<AutenUsr>(entity =>
        {
            entity.HasKey(e => e.IdAuten);

            entity.ToTable("AutenUsr");

            entity.Property(e => e.Aapellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AApellido");
            entity.Property(e => e.Aestatus).HasColumnName("AEstatus");
            entity.Property(e => e.Anivel).HasColumnName("ANivel");
            entity.Property(e => e.Anombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ANombre");
            entity.Property(e => e.AuFicha)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AuPass)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CargoPm>(entity =>
        {
            entity.HasKey(e => e.IdCargoPm);

            entity.ToTable("CargoPM", tb => tb.HasComment("cargos registrados en las reuniones de las paradas por mantenimiento"));

            entity.Property(e => e.IdCargoPm)
                .HasComment("identificador")
                .HasColumnName("IdCargoPM");
            entity.Property(e => e.Cpmnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("cargo del asistidor")
                .HasColumnName("CPMNom");
        });

        modelBuilder.Entity<CargoReu>(entity =>
        {
            entity.HasKey(e => e.IdCargoR);

            entity.ToTable("CargoReu");

            entity.Property(e => e.Cearea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CEArea");
            entity.Property(e => e.Crempresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREmpresa");
            entity.Property(e => e.Cresta).HasColumnName("CREsta");
            entity.Property(e => e.Crnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRNombre");
        });

        modelBuilder.Entity<Centro>(entity =>
        {
            entity.HasKey(e => e.IdCentro);

            entity.ToTable("Centro", tb => tb.HasComment("centro de produccion"));

            entity.Property(e => e.IdCentro).HasComment("identificador del centro");
            entity.Property(e => e.Cdetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("Detalle del centro")
                .HasColumnName("CDetalle");
            entity.Property(e => e.Cestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("CEstado");
            entity.Property(e => e.Cnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("nombre del centro")
                .HasColumnName("CNom");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Centros)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_Centro_Empresa");
        });

        modelBuilder.Entity<ClasifiTpm>(entity =>
        {
            entity.HasKey(e => e.IdCtpm);

            entity.ToTable("ClasifiTPM");

            entity.Property(e => e.IdCtpm).HasColumnName("IdCTPM");
            entity.Property(e => e.Ctpmestado).HasColumnName("CTPMEstado");
            entity.Property(e => e.Ctpmnom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CTPMNom");
        });

        modelBuilder.Entity<ClienteP>(entity =>
        {
            entity.HasKey(e => e.IdClienteP);

            entity.ToTable("ClienteP", tb => tb.HasComment("Area solicitante"));

            entity.Property(e => e.IdClienteP).HasComment("Identificador del cliente del proyecto");
            entity.Property(e => e.Cpdescri)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("decripcion del area")
                .HasColumnName("CPDescri");
            entity.Property(e => e.Cpestatus)
                .HasComment("estatus(0:inactivo,1:activo)")
                .HasColumnName("CPEstatus");
            entity.Property(e => e.Cpnombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("nombre del area")
                .HasColumnName("CPNombre");
        });

        modelBuilder.Entity<DatAudCa>(entity =>
        {
            entity.HasKey(e => e.IdDatAudCa);

            entity.ToTable("DatAudCa", tb => tb.HasComment("data de la auditoria"));

            entity.Property(e => e.IdDatAudCa).HasComment("Identificador del dato");
            entity.Property(e => e.DacisAcep)
                .HasComment("0: no aceptable, 1:aceptable")
                .HasColumnName("DACIsAcep");
            entity.Property(e => e.Dacvalor)
                .HasComment("valor observado")
                .HasColumnName("DACValor");
            entity.Property(e => e.IdAudCa).HasComment("identificador de la auditoria");
            entity.Property(e => e.IdVarCa).HasComment("identificador de la variable");

            entity.HasOne(d => d.IdAudCaNavigation).WithMany(p => p.DatAudCas)
                .HasForeignKey(d => d.IdAudCa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DatAudCa_AudCa");

            entity.HasOne(d => d.IdVarCaNavigation).WithMany(p => p.DatAudCas)
                .HasForeignKey(d => d.IdVarCa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DatAudCa_VarCa");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.IdDivision);

            entity.ToTable("Division");

            entity.Property(e => e.Ddetalle)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DDetalle");
            entity.Property(e => e.Destado).HasColumnName("DEstado");
            entity.Property(e => e.Dnombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DNombre");

            entity.HasOne(d => d.IdCentroNavigation).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.IdCentro)
                .HasConstraintName("FK_Division_Centro");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.ToTable("Empresa");

            entity.Property(e => e.Edescri)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDescri");
            entity.Property(e => e.Eestado).HasColumnName("EEstado");
            entity.Property(e => e.Enombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENombre");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_Pais");
        });

        modelBuilder.Entity<IdAreaConLinea>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IdAreaConLinea");

            entity.Property(e => e.Anom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ANom");
            entity.Property(e => e.Lnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("LNom");
        });

        modelBuilder.Entity<Ksf>(entity =>
        {
            entity.HasKey(e => e.Idksf);

            entity.ToTable("KSF");

            entity.Property(e => e.KsfNombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LibroNove>(entity =>
        {
            entity.HasKey(e => e.IdlibrNov).HasName("PK_LibroNovedades");

            entity.ToTable("LibroNove");

            entity.Property(e => e.IdCtpm).HasColumnName("IdCTPM");
            entity.Property(e => e.IdEquipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdMaquina)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdParada)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lndiscrepa)
                .IsUnicode(false)
                .HasColumnName("LNDiscrepa");
            entity.Property(e => e.Lnfecha)
                .HasColumnType("datetime")
                .HasColumnName("LNFecha");
            entity.Property(e => e.LnfichaRes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LNFichaRes");
            entity.Property(e => e.Lngrupo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LNGrupo");
            entity.Property(e => e.LnisPizUni).HasColumnName("LNIsPizUni");
            entity.Property(e => e.LnisResu).HasColumnName("LNIsResu");
            entity.Property(e => e.Lnobserv)
                .IsUnicode(false)
                .HasColumnName("LNObserv");
            entity.Property(e => e.LntiePerMi).HasColumnName("LNTiePerMi");
            entity.Property(e => e.Lnturno)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LNTurno");

            entity.HasOne(d => d.IdAreaCarNavigation).WithMany(p => p.LibroNoves)
                .HasForeignKey(d => d.IdAreaCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LibroNove_Centro");

            entity.HasOne(d => d.IdCtpmNavigation).WithMany(p => p.LibroNoves)
                .HasForeignKey(d => d.IdCtpm)
                .HasConstraintName("FK_LibroNove_ClasifiTPM");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.LibroNoves)
                .HasForeignKey(d => d.IdLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LibroNove_Linea");

            entity.HasOne(d => d.IdTipoNoveNavigation).WithMany(p => p.LibroNoves)
                .HasForeignKey(d => d.IdTipoNove)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LibroNove_TiParTP");
        });

        modelBuilder.Entity<LinAre>(entity =>
        {
            entity.HasKey(e => e.IdLinAre);

            entity.ToTable("LinAre", tb => tb.HasComment("ntermediario entre linea y area"));

            entity.Property(e => e.IdLinAre).HasComment("Identificador");
            entity.Property(e => e.IdLinea).HasComment("Codigo de la linea con area");
            entity.Property(e => e.Lacodigo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Codigo de la linea con area")
                .HasColumnName("LACodigo");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.LinAres)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinAre_Area");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.LinAres)
                .HasForeignKey(d => d.IdLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinAre_Linea");
        });

        modelBuilder.Entity<LinPro>(entity =>
        {
            entity.HasKey(e => e.IdLinPro);

            entity.ToTable("LinPro", tb => tb.HasComment("intermediario entre linea y producto"));

            entity.Property(e => e.IdLinPro).HasComment("identificador de la Lin_Pro");
            entity.Property(e => e.IdLinea).HasComment("identificador de la linea");
            entity.Property(e => e.IdProducto).HasComment("identificador del producto");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.LinPros)
                .HasForeignKey(d => d.IdLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinPro_Linea");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.LinPros)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinPro_Producto");
        });

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.IdLinea);

            entity.ToTable("Linea", tb => tb.HasComment("linea de produccion"));

            entity.Property(e => e.IdLinea).HasComment("identificador de la linea");
            entity.Property(e => e.IdCentro).HasComment("identificador del centro");
            entity.Property(e => e.LcenCos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LCenCos");
            entity.Property(e => e.Ldetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("Detalle de la linea")
                .HasColumnName("LDetalle");
            entity.Property(e => e.Lestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("LEstado");
            entity.Property(e => e.Lnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("nombre de la linea")
                .HasColumnName("LNom");
            entity.Property(e => e.Lofic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOFIC");

            entity.HasOne(d => d.IdCentroNavigation).WithMany(p => p.Lineas)
                .HasForeignKey(d => d.IdCentro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Linea_Centro");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.Lineas)
                .HasForeignKey(d => d.IdDivision)
                .HasConstraintName("FK_Linea_Division");
        });

        modelBuilder.Entity<Nivel>(entity =>
        {
            entity.HasKey(e => e.IdNivel);

            entity.ToTable("Nivel");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.Nivels)
                .HasForeignKey(d => d.IdDivision)
                .HasConstraintName("FK_Nivel_Division");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Nivels)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nivel_ProyectoUsr");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Nivels)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Nivel_Rol");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Nivels)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nivel_Usuario");
        });

        modelBuilder.Entity<NovedadesActualesChempro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NovedadesActualesChempro");

            entity.Property(e => e.Centro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CodigoEquipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo Equipo");
            entity.Property(e => e.Discrepancia).IsUnicode(false);
            entity.Property(e => e.FichaDelRegistrador)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ficha del Registrador");
            entity.Property(e => e.Grupo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Linea)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Lnfecha)
                .HasColumnType("datetime")
                .HasColumnName("LNFecha");
            entity.Property(e => e.Observacion).IsUnicode(false);
            entity.Property(e => e.TiempoPerdido).HasColumnName("Tiempo Perdido");
            entity.Property(e => e.TipoDeNovedad)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Tipo de Novedad");
            entity.Property(e => e.Turno)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Operador>(entity =>
        {
            entity.HasKey(e => e.IdOperador);

            entity.ToTable("Operador");

            entity.Property(e => e.IdOperador).HasComment("identificador");
            entity.Property(e => e.Opapellido)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("apellido del operador		")
                .HasColumnName("OPApellido");
            entity.Property(e => e.Opestado)
                .HasComment("0: Inactivo, 1:Activo		")
                .HasColumnName("OPEstado");
            entity.Property(e => e.OpfechaIng)
                .HasComment("fecha de ingreso		")
                .HasColumnType("date")
                .HasColumnName("OPFechaIng");
            entity.Property(e => e.OpfechaNac)
                .HasComment("fecha de nacimiento		")
                .HasColumnType("date")
                .HasColumnName("OPFechaNac");
            entity.Property(e => e.Opficha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("ficha del operador")
                .HasColumnName("OPFicha");
            entity.Property(e => e.Opnombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("nombre del operador		")
                .HasColumnName("OPNombre");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais);

            entity.Property(e => e.Pestado).HasColumnName("PEstado");
            entity.Property(e => e.Pnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PNombre");
        });

        modelBuilder.Entity<ParAre>(entity =>
        {
            entity.HasKey(e => e.IdParAre);

            entity.ToTable("ParAre", tb => tb.HasComment("intermediario entre la parte y el area"));

            entity.Property(e => e.IdParAre).HasComment("identificador del Par_Are");
            entity.Property(e => e.IdArea).HasComment("identificador del area");
            entity.Property(e => e.IdParte).HasComment("identifiacador de la parte");
            entity.Property(e => e.Pacodigo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("codigo de la parte correspondiente al area		")
                .HasColumnName("PACodigo");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.ParAres)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParAre_LinAre");

            entity.HasOne(d => d.IdParteNavigation).WithMany(p => p.ParAres)
                .HasForeignKey(d => d.IdParte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParAre_Parte");
        });

        modelBuilder.Entity<ParaTp>(entity =>
        {
            entity.HasKey(e => e.IdParaTp);

            entity.ToTable("ParaTP", tb => tb.HasComment("Paradas de la linia"));

            entity.Property(e => e.IdParaTp)
                .HasComment("identificador de la parada")
                .HasColumnName("IdParaTP");
            entity.Property(e => e.IdTiParTp)
                .HasComment("identificador del tipo de la parada")
                .HasColumnName("IdTiParTP");
            entity.Property(e => e.Pcodigo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("codigo de la parada")
                .HasColumnName("PCodigo");
            entity.Property(e => e.Pestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("PEstado");
            entity.Property(e => e.Pnombre)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasComment("nombre de la parada")
                .HasColumnName("PNombre");

            entity.HasOne(d => d.IdTiParTpNavigation).WithMany(p => p.ParaTps)
                .HasForeignKey(d => d.IdTiParTp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParaTP_TiParTP");
        });

        modelBuilder.Entity<ParsiOee>(entity =>
        {
            entity.HasKey(e => e.IdParsiOee);

            entity.ToTable("ParsiOEE", "his", tb => tb.HasComment("datos obteneidos de un area especifico del turno en curso"));

            entity.Property(e => e.IdParsiOee)
                .HasComment("identificador del turno")
                .HasColumnName("IdParsiOEE");
            entity.Property(e => e.IdArea).HasComment("identificador de la linea");
            entity.Property(e => e.IdTurnoTp)
                .HasComment("identificador del turno en curso")
                .HasColumnName("IdTurnoTP");
            entity.Property(e => e.Pcalidad)
                .HasComment("calidad del turno")
                .HasColumnName("PCalidad");
            entity.Property(e => e.Pdispo)
                .HasComment("disponibilidad del turno")
                .HasColumnName("PDispo");
            entity.Property(e => e.Poee)
                .HasComment("OEE del turno")
                .HasColumnName("POEE");
            entity.Property(e => e.Ppbueno)
                .HasComment("productos buenos del turno")
                .HasColumnName("PPBueno");
            entity.Property(e => e.Pperdido)
                .HasComment("tiempo perdido del turno")
                .HasColumnName("PPerdido");
            entity.Property(e => e.Ppmalo)
                .HasComment("productos malos del turno")
                .HasColumnName("PPMalo");
            entity.Property(e => e.Prendi)
                .HasComment("rendimiento del turno")
                .HasColumnName("PRendi");
            entity.Property(e => e.Ptrabajado)
                .HasComment("tiempo trabajo del turno")
                .HasColumnName("PTrabajado");
            entity.Property(e => e.Pvelocidad)
                .HasComment("velocidad promedio del turno")
                .HasColumnName("PVelocidad");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.ParsiOees)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParsiOEE_LinAre");

            entity.HasOne(d => d.IdTurnoTpNavigation).WithMany(p => p.ParsiOees)
                .HasForeignKey(d => d.IdTurnoTp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParsiOEE_TurnoTP");
        });

        modelBuilder.Entity<Parte>(entity =>
        {
            entity.HasKey(e => e.IdParte);

            entity.ToTable("Parte", tb => tb.HasComment("Partes que componen el area"));

            entity.Property(e => e.IdParte).HasComment("identificador");
            entity.Property(e => e.Pdetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("detalle de la parte")
                .HasColumnName("PDetalle");
            entity.Property(e => e.Pestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("PEstado");
            entity.Property(e => e.Pnombre)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasComment("nombre de la parte")
                .HasColumnName("PNombre");
        });

        modelBuilder.Entity<ParteLineaAreaCentro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ParteLineaAreaCentro");

            entity.Property(e => e.Area)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Centro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CodigoDelArea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo del Area");
            entity.Property(e => e.CodigocDeLaParte)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigoc de la Parte");
            entity.Property(e => e.Linea)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Parte)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.IdPersonal).HasName("PK__Personal__05A9201B1DEC2386");

            entity.ToTable("Personal");

            entity.Property(e => e.PeApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PeFicha)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PeNombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAreaTraNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdAreaTra)
                .HasConstraintName("FK__Personal__IdArea__5B438874");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FK__Personal__IdPues__5C37ACAD");
        });

        modelBuilder.Entity<Plantum>(entity =>
        {
            entity.HasKey(e => e.IdPlanta).HasName("PK__Planta__12FEC124F71E3A67");

            entity.Property(e => e.PlCodigo)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PlDescri)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PregP>(entity =>
        {
            entity.HasKey(e => e.IdPregP);

            entity.ToTable("PregP", tb => tb.HasComment("preguntas de satisfaccion"));

            entity.Property(e => e.IdPregP).HasComment("identificador de la pregunta");
            entity.Property(e => e.Ppestatus)
                .HasComment("estatus(0:inactivo,1:activo)")
                .HasColumnName("PPEstatus");
            entity.Property(e => e.PpisObser)
                .HasComment("(0:no tiene observacion,1: tiene observacion)")
                .HasColumnName("PPIsObser");
            entity.Property(e => e.Ppnombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("pregunta de la encuesta")
                .HasColumnName("PPNombre");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("Producto", tb => tb.HasComment("Productos"));

            entity.Property(e => e.IdProducto).HasComment("identificador");
            entity.Property(e => e.Pcodigo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Codigo del producto")
                .HasColumnName("PCodigo");
            entity.Property(e => e.Pdetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("detalle de la parte")
                .HasColumnName("PDetalle");
            entity.Property(e => e.Pestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("PEstado");
            entity.Property(e => e.Pnombre)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasComment("nombre de la parte")
                .HasColumnName("PNombre");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto);

            entity.ToTable("Proyecto", "his", tb => tb.HasComment("Proyecto de Mejora Continua"));

            entity.Property(e => e.IdProyecto).HasComment("Identificador del proyecto");
            entity.Property(e => e.IdClienteP).HasComment("identificador del cliente");
            entity.Property(e => e.IdRspnsblP).HasComment("identificador del responsable");
            entity.Property(e => e.Pdetalle)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasComment("detalle del proyecto")
                .HasColumnName("PDetalle");
            entity.Property(e => e.PfechaC)
                .HasComment("fecha del cierre del proyecto")
                .HasColumnType("date")
                .HasColumnName("PFechaC");
            entity.Property(e => e.PfechaP)
                .HasComment("fecha programada")
                .HasColumnType("date")
                .HasColumnName("PFechaP");
            entity.Property(e => e.PfechaS)
                .HasComment("fecha de la solicitud")
                .HasColumnType("date")
                .HasColumnName("PFechaS");
            entity.Property(e => e.Pfechai)
                .HasComment("fecha de inicio del poyecto")
                .HasColumnType("date")
                .HasColumnName("PFechai");
            entity.Property(e => e.PisEncue)
                .HasComment("0:no se ha realizado la encuesta, 1: se realizo")
                .HasColumnName("PIsEncue");
            entity.Property(e => e.Pnombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("nombre del proyecto")
                .HasColumnName("PNombre");
            entity.Property(e => e.Pnota)
                .HasComment("nota de la encuesta")
                .HasColumnName("PNota");

            entity.HasOne(d => d.IdClientePNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdClienteP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proyecto_ClienteP");

            entity.HasOne(d => d.IdRspnsblPNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdRspnsblP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proyecto_RspnsblP");
        });

        modelBuilder.Entity<ProyectoUsr>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK_Proyecto_1");

            entity.ToTable("ProyectoUsr");

            entity.Property(e => e.Pestado).HasColumnName("PEstado");
            entity.Property(e => e.Pnombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PNombre");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.IdPuesto).HasName("PK__Puesto__ADAC6B9C1C93A40D");

            entity.ToTable("Puesto");

            entity.Property(e => e.PuCodigo)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PuDescri)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RespP>(entity =>
        {
            entity.HasKey(e => e.IdRespP);

            entity.ToTable("RespP", tb => tb.HasComment("Respuesta de las preguntas por proyectos"));

            entity.Property(e => e.IdRespP).HasComment("Identificador de la respuesta del proyecto");
            entity.Property(e => e.IdPregP).HasComment("identificador de la pregunta del proyecto");
            entity.Property(e => e.IdProyecto).HasComment("identificador del proyecto");
            entity.Property(e => e.Rpcumpli)
                .HasComment("nota de la pregunta")
                .HasColumnName("RPCumpli");
            entity.Property(e => e.Rpobserv)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasComment("observacion de la pregunta")
                .HasColumnName("RPObserv");

            entity.HasOne(d => d.IdPregPNavigation).WithMany(p => p.RespPs)
                .HasForeignKey(d => d.IdPregP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RespP_PregP");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.RespPs)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RespP_Proyecto");
        });

        modelBuilder.Entity<RespoReu>(entity =>
        {
            entity.HasKey(e => e.IdResReu);

            entity.ToTable("RespoReu");

            entity.Property(e => e.Rresta).HasColumnName("RREsta");
            entity.Property(e => e.Rrnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RRNombre");
        });

        modelBuilder.Entity<Resuman>(entity =>
        {
            entity.HasKey(e => e.IdResumen).HasName("PK__Resumen__C15B26E506657487");

            entity.Property(e => e.AreaTra)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rfecha)
                .HasColumnType("datetime")
                .HasColumnName("RFecha");
            entity.Property(e => e.Rgrupo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("RGrupo");
            entity.Property(e => e.RisSplncia).HasColumnName("RIsSplncia");
            entity.Property(e => e.Rplanta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RPlanta");
            entity.Property(e => e.Rpuesto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RPuesto");
            entity.Property(e => e.RsupFicha)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("RSupFicha");
            entity.Property(e => e.Rsuplido)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("RSuplido");
            entity.Property(e => e.RtraFicha)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("RTraFicha");
            entity.Property(e => e.Rtrabajado)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("RTrabajado");
            entity.Property(e => e.Rturno)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("RTurno");

            entity.HasOne(d => d.IdTipSupleNavigation).WithMany(p => p.Resumen)
                .HasForeignKey(d => d.IdTipSuple)
                .HasConstraintName("FK__Resumen__IdTipSu__5E1FF51F");
        });

        modelBuilder.Entity<ReuParM>(entity =>
        {
            entity.HasKey(e => e.IdReuParM);

            entity.ToTable("ReuParM", tb => tb.HasComment("reuniones de paradas por mantenimiento"));

            entity.Property(e => e.IdReuParM).HasComment("identificador");
            entity.Property(e => e.Rparea)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("area en la que se realizo la parada planificada")
                .HasColumnName("RPArea");
            entity.Property(e => e.RpasunSpa)
                .HasComment("asuntos tratados en el SPA")
                .HasColumnName("RPAsunSPA");
            entity.Property(e => e.RpfechaPar)
                .HasComment("fecha de la parada planificada")
                .HasColumnType("date")
                .HasColumnName("RPFechaPar");
            entity.Property(e => e.RpfechaReu)
                .HasComment("fecha de la reunion")
                .HasColumnType("date")
                .HasColumnName("RPFechaReu");
            entity.Property(e => e.Rpmaquina)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasComment("maquina de la parada programada")
                .HasColumnName("RPMaquina");
            entity.Property(e => e.RpnumAct)
                .HasComment("numero actividades de la parada")
                .HasColumnName("RPNumAct");
            entity.Property(e => e.Rpporce)
                .HasComment("Porcentaje de asistencia")
                .HasColumnName("RPPorce");
            entity.Property(e => e.RptiePar)
                .HasComment("tiempo de la parada planificada")
                .HasColumnName("RPTiePar");
            entity.Property(e => e.RptipReu)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("tipo de reunion")
                .HasColumnName("RPTipReu");
        });

        modelBuilder.Entity<ReunionDium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BD_Div1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AfectadoKsf)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodigoEquipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo_equipo");
            entity.Property(e => e.Discrepancia)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Div)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Division)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Fecha2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaTrab)
                .HasColumnType("date")
                .HasColumnName("Fecha_trab");
            entity.Property(e => e.FechaTrab1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Fecha_trab1");
            entity.Property(e => e.OrdenTrabajo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlanDeAccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Plan_de_accion");
            entity.Property(e => e.Produfin)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Responsable)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tiempo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("Rol");

            entity.Property(e => e.Rdescri)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("RDescri");
            entity.Property(e => e.Restado).HasColumnName("REstado");
            entity.Property(e => e.Rnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RNombre");
        });

        modelBuilder.Entity<RspnsblP>(entity =>
        {
            entity.HasKey(e => e.IdRspnsblP);

            entity.ToTable("RspnsblP", tb => tb.HasComment("Responsable del proyecto"));

            entity.Property(e => e.IdRspnsblP).HasComment("Identificador del cliente del proyecto");
            entity.Property(e => e.Rpestatus)
                .HasComment("estatus(0:inactivo,1:activo)")
                .HasColumnName("RPEstatus");
            entity.Property(e => e.Rpnombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("nombre del responsable")
                .HasColumnName("RPNombre");
            entity.Property(e => e.Rpusuario)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("RPUsuario");
        });

        modelBuilder.Entity<TecniCa>(entity =>
        {
            entity.HasKey(e => e.IdTecniCa);

            entity.ToTable("TecniCa", tb => tb.HasComment("tecnicos de calidad"));

            entity.Property(e => e.Tcestado).HasColumnName("TCEstado");
            entity.Property(e => e.Tcficha)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TCFicha");
            entity.Property(e => e.Tcnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TCNom");
            entity.Property(e => e.TcusuW)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TCUsuW");
        });

        modelBuilder.Entity<TiPaPar>(entity =>
        {
            entity.HasKey(e => e.IdTiPaPar);

            entity.ToTable("TiPaPar", tb => tb.HasComment("intermediario entre el tipo de parada y la parte"));

            entity.Property(e => e.IdTiPaPar).HasComment("identificador del TiPa_Par");
            entity.Property(e => e.IdParte).HasComment("identifiacador de la parte");
            entity.Property(e => e.IdTiParTp)
                .HasComment("identificador de tipo de parada")
                .HasColumnName("IdTiParTP");

            entity.HasOne(d => d.IdParteNavigation).WithMany(p => p.TiPaPars)
                .HasForeignKey(d => d.IdParte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TiPaPar_Parte");

            entity.HasOne(d => d.IdTiParTpNavigation).WithMany(p => p.TiPaPars)
                .HasForeignKey(d => d.IdTiParTp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TiPaPar_TiParTP");
        });

        modelBuilder.Entity<TiParTp>(entity =>
        {
            entity.HasKey(e => e.IdTiParTp);

            entity.ToTable("TiParTP", tb => tb.HasComment("tipo de parada del tiempo perdido"));

            entity.Property(e => e.IdTiParTp)
                .HasComment("identificador")
                .HasColumnName("IdTiParTP");
            entity.Property(e => e.Tpcodigo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("codigo del tipo parada")
                .HasColumnName("TPCodigo");
            entity.Property(e => e.Tpestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("TPEstado");
            entity.Property(e => e.Tpnombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("nombre del centro")
                .HasColumnName("TPNombre");
        });

        modelBuilder.Entity<TieEjeTp>(entity =>
        {
            entity.HasKey(e => e.IdTieEjeTp);

            entity.ToTable("TieEjeTP", tb => tb.HasComment("tiempo ejecutado en el turno"));

            entity.Property(e => e.IdTieEjeTp)
                .HasComment("identificador del tiempo ejecutado de un turno")
                .HasColumnName("IdTieEjeTP");
            entity.Property(e => e.IdParsiOee)
                .HasComment("identificador del turno")
                .HasColumnName("IdParsiOEE");
            entity.Property(e => e.Tebueno)
                .HasComment("cantidad de productos buenos")
                .HasColumnName("TEBueno");
            entity.Property(e => e.Teduracion)
                .HasComment("duracion del tiempo ejecutado")
                .HasColumnName("TEDuracion");
            entity.Property(e => e.Tefechaf)
                .HasComment("fecha final del tiempo ejecutado")
                .HasColumnType("datetime")
                .HasColumnName("TEFechaf");
            entity.Property(e => e.Tefechai)
                .HasComment("fecha de inicio del tiempo ejecutado")
                .HasColumnType("datetime")
                .HasColumnName("TEFechai");
            entity.Property(e => e.Temalo)
                .HasComment("cantidad de productos malos")
                .HasColumnName("TEMalo");
            entity.Property(e => e.TenumVuelt).HasColumnName("TENumVuelt");
            entity.Property(e => e.Teproducidos).HasColumnName("TEProducidos");
            entity.Property(e => e.Tevelocidad)
                .HasComment("velocidad promedio")
                .HasColumnName("TEVelocidad");

            entity.HasOne(d => d.IdParsiOeeNavigation).WithMany(p => p.TieEjeTps)
                .HasForeignKey(d => d.IdParsiOee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TieEjeTP_ParsiOEE");
        });

        modelBuilder.Entity<TieParTp>(entity =>
        {
            entity.HasKey(e => e.IdTieParTp);

            entity.ToTable("TieParTP", tb => tb.HasComment("tiempo parado en el turno"));

            entity.Property(e => e.IdTieParTp)
                .HasComment("identificador del tiempo parado de un turno")
                .HasColumnName("IdTieParTP");
            entity.Property(e => e.IdParaTp)
                .HasComment("identificador de la parada")
                .HasColumnName("IdParaTP");
            entity.Property(e => e.IdParsiOee)
                .HasComment("identificador del turno")
                .HasColumnName("IdParsiOEE");
            entity.Property(e => e.Teduracion)
                .HasComment("duracion de la parada")
                .HasColumnName("TEDuracion");
            entity.Property(e => e.Tefechaf)
                .HasComment("fecha final de la parada")
                .HasColumnType("datetime")
                .HasColumnName("TEFechaf");
            entity.Property(e => e.Tefechai)
                .HasComment("fecha de inicio de la parada")
                .HasColumnType("datetime")
                .HasColumnName("TEFechai");

            entity.HasOne(d => d.IdParaTpNavigation).WithMany(p => p.TieParTps)
                .HasForeignKey(d => d.IdParaTp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TieParTP_ParaTP");

            entity.HasOne(d => d.IdParsiOeeNavigation).WithMany(p => p.TieParTps)
                .HasForeignKey(d => d.IdParsiOee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TieParTP_ParsiOEE");
        });

        modelBuilder.Entity<TipSuple>(entity =>
        {
            entity.HasKey(e => e.IdTipSuple).HasName("PK__TipSuple__9ECDEC913F95291A");

            entity.ToTable("TipSuple");

            entity.Property(e => e.Tscodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("TSCodigo");
            entity.Property(e => e.Tsdescri)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TSDescri");
            entity.Property(e => e.Tsestado).HasColumnName("TSEstado");
        });

        modelBuilder.Entity<TurPro>(entity =>
        {
            entity.HasKey(e => e.IdTurPro);

            entity.ToTable("TurPro", tb => tb.HasComment("intermediario entre turno del tiempo perdido y producto"));

            entity.Property(e => e.IdTurPro).HasComment("identificador de la Tur_Pro");
            entity.Property(e => e.IdProducto).HasComment("identificador del producto");
            entity.Property(e => e.IdTurnoTp)
                .HasComment("identificador del turno")
                .HasColumnName("IdTurnoTP");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TurPros)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TurPro_Producto");

            entity.HasOne(d => d.IdTurnoTpNavigation).WithMany(p => p.TurPros)
                .HasForeignKey(d => d.IdTurnoTp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TurPro_TurnoTP");
        });

        modelBuilder.Entity<TurnoTp>(entity =>
        {
            entity.HasKey(e => e.IdTurnoTp);

            entity.ToTable("TurnoTP", tb => tb.HasComment("turnos de tiempo perdido"));

            entity.Property(e => e.IdTurnoTp)
                .HasComment("identificador del turno")
                .HasColumnName("IdTurnoTP");
            entity.Property(e => e.IdLinea).HasComment("identificador de la linea");
            entity.Property(e => e.IdOperador).HasComment("identificador del operador");
            entity.Property(e => e.Tcalidad)
                .HasComment("calidad del turno")
                .HasColumnName("TCalidad");
            entity.Property(e => e.Tdispo)
                .HasComment("disponibilidad del turno")
                .HasColumnName("TDispo");
            entity.Property(e => e.Tfecha)
                .HasComment("fecha del turno")
                .HasColumnType("datetime")
                .HasColumnName("TFecha");
            entity.Property(e => e.Toee)
                .HasComment("OEE del turno")
                .HasColumnName("TOEE");
            entity.Property(e => e.Tpbueno)
                .HasComment("productos buenos del turno")
                .HasColumnName("TPBueno");
            entity.Property(e => e.Tperdido)
                .HasComment("tiempo perdido del turno")
                .HasColumnName("TPerdido");
            entity.Property(e => e.Tpmalo)
                .HasComment("productos malos del turno")
                .HasColumnName("TPMalo");
            entity.Property(e => e.Trendi)
                .HasComment("rendimiento del turno")
                .HasColumnName("TRendi");
            entity.Property(e => e.Ttrabajado)
                .HasComment("tiempo trabajo del turno")
                .HasColumnName("TTrabajado");
            entity.Property(e => e.Tturno)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("turno en curso");
            entity.Property(e => e.Tvelocidad)
                .HasComment("velocidad promedio del turno")
                .HasColumnName("TVelocidad");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.TurnoTps)
                .HasForeignKey(d => d.IdLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TurnoTP_Linea");

            entity.HasOne(d => d.IdOperadorNavigation).WithMany(p => p.TurnoTps)
                .HasForeignKey(d => d.IdOperador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TurnoTP_Operador");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario", tb => tb.HasComment("Responsable del proyecto"));

            entity.Property(e => e.IdUsuario).HasComment("Identificador del usuario");
            entity.Property(e => e.UsApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsClave)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UsCorreo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsEstatus).HasComment("estatus(0:inactivo,1:activo)");
            entity.Property(e => e.UsFicha)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsNombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("nombre del usuario");
            entity.Property(e => e.UsPass)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuariosPermiso>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Usuarios_Permisos");

            entity.Property(e => e.Centro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Division)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proyecto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsFicha)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsNombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UsUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VarAre>(entity =>
        {
            entity.HasKey(e => e.IdVarAre);

            entity.ToTable("VarAre", tb => tb.HasComment("intermediario entre vareable de calidad y area"));

            entity.Property(e => e.IdVarAre).HasComment("identificador de la Var_Are");
            entity.Property(e => e.IdArea).HasComment("identifiacador del area");
            entity.Property(e => e.IdVarCa).HasComment("identificador de la variable de calidad");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.VarAres)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VarAre_Area");

            entity.HasOne(d => d.IdVarCaNavigation).WithMany(p => p.VarAres)
                .HasForeignKey(d => d.IdVarCa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VarAre_VarCa");
        });

        modelBuilder.Entity<VarCa>(entity =>
        {
            entity.HasKey(e => e.IdVarCa);

            entity.ToTable("VarCa", tb => tb.HasComment("variable de calidad auditadas"));

            entity.Property(e => e.IdVarCa).HasComment("identificador de la variable de calidad");
            entity.Property(e => e.Vcdetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("Detalle de la variable")
                .HasColumnName("VCDetalle");
            entity.Property(e => e.Vcestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("VCEstado");
            entity.Property(e => e.Vcisobser)
                .HasComment("0: no de tipo observable 1:es de tipo numerico")
                .HasColumnName("VCIsobser");
            entity.Property(e => e.Vcnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("nombre de la variable")
                .HasColumnName("VCNom");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

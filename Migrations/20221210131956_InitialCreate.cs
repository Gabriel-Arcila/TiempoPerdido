using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiempoPerdido.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "his");

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false, comment: "identificador del area")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ANom = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "nombre del area"),
                    ADetalle = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true, comment: "Detalle del area"),
                    AEstado = table.Column<bool>(type: "bit", nullable: false, comment: "0: Inactivo, 1:Activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.IdArea);
                },
                comment: "Area de produccion");

            migrationBuilder.CreateTable(
                name: "AutenUsr",
                columns: table => new
                {
                    IdAuten = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuFicha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AuPass = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ANombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AApellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ANivel = table.Column<int>(type: "int", nullable: true),
                    AEstatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutenUsr", x => x.IdAuten);
                });

            migrationBuilder.CreateTable(
                name: "CargoPM",
                columns: table => new
                {
                    IdCargoPM = table.Column<int>(type: "int", nullable: false, comment: "identificador")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPMNom = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true, comment: "cargo del asistidor")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoPM", x => x.IdCargoPM);
                },
                comment: "cargos registrados en las reuniones de las paradas por mantenimiento");

            migrationBuilder.CreateTable(
                name: "CargoReu",
                columns: table => new
                {
                    IdCargoR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRNombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CREsta = table.Column<bool>(type: "bit", nullable: false),
                    CREmpresa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CEArea = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoReu", x => x.IdCargoR);
                });

            migrationBuilder.CreateTable(
                name: "ClasifiTPM",
                columns: table => new
                {
                    IdCTPM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTPMNom = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CTPMEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasifiTPM", x => x.IdCTPM);
                });

            migrationBuilder.CreateTable(
                name: "ClienteP",
                columns: table => new
                {
                    IdClienteP = table.Column<int>(type: "int", nullable: false, comment: "Identificador del cliente del proyecto")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPNombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, comment: "nombre del area"),
                    CPDescri = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true, comment: "decripcion del area"),
                    CPEstatus = table.Column<bool>(type: "bit", nullable: false, comment: "estatus(0:inactivo,1:activo)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteP", x => x.IdClienteP);
                },
                comment: "Area solicitante");

            migrationBuilder.CreateTable(
                name: "KSF",
                columns: table => new
                {
                    Idksf = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KsfNombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    KsfEsta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KSF", x => x.Idksf);
                });

            migrationBuilder.CreateTable(
                name: "Operador",
                columns: table => new
                {
                    IdOperador = table.Column<int>(type: "int", nullable: false, comment: "identificador")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OPFicha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "ficha del operador"),
                    OPNombre = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "nombre del operador		"),
                    OPApellido = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true, comment: "apellido del operador		"),
                    OPFechaNac = table.Column<DateTime>(type: "date", nullable: true, comment: "fecha de nacimiento		"),
                    OPFechaIng = table.Column<DateTime>(type: "date", nullable: true, comment: "fecha de ingreso		"),
                    OPEstado = table.Column<bool>(type: "bit", nullable: false, comment: "0: Inactivo, 1:Activo		")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operador", x => x.IdOperador);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    IdPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.IdPais);
                });

            migrationBuilder.CreateTable(
                name: "Parte",
                columns: table => new
                {
                    IdParte = table.Column<int>(type: "int", nullable: false, comment: "identificador")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNombre = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false, comment: "nombre de la parte"),
                    PDetalle = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true, comment: "detalle de la parte"),
                    PEstado = table.Column<bool>(type: "bit", nullable: false, comment: "0: Inactivo, 1:Activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parte", x => x.IdParte);
                },
                comment: "Partes que componen el area");

            migrationBuilder.CreateTable(
                name: "Planta",
                columns: table => new
                {
                    IdPlanta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlCodigo = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    PlDescri = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    PlEstado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Planta__12FEC124F71E3A67", x => x.IdPlanta);
                });

            migrationBuilder.CreateTable(
                name: "PregP",
                columns: table => new
                {
                    IdPregP = table.Column<int>(type: "int", nullable: false, comment: "identificador de la pregunta")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PPNombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, comment: "pregunta de la encuesta"),
                    PPIsObser = table.Column<bool>(type: "bit", nullable: false, comment: "(0:no tiene observacion,1: tiene observacion)"),
                    PPEstatus = table.Column<bool>(type: "bit", nullable: false, comment: "estatus(0:inactivo,1:activo)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregP", x => x.IdPregP);
                },
                comment: "preguntas de satisfaccion");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false, comment: "identificador")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PCodigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "Codigo del producto"),
                    PNombre = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false, comment: "nombre de la parte"),
                    PDetalle = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true, comment: "detalle de la parte"),
                    PEstado = table.Column<bool>(type: "bit", nullable: false, comment: "0: Inactivo, 1:Activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                },
                comment: "Productos");

            migrationBuilder.CreateTable(
                name: "ProyectoUsr",
                columns: table => new
                {
                    IdProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto_1", x => x.IdProyecto);
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    IdPuesto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuCodigo = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    PuDescri = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    PuEstado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Puesto__ADAC6B9C1C93A40D", x => x.IdPuesto);
                });

            migrationBuilder.CreateTable(
                name: "RespoReu",
                columns: table => new
                {
                    IdResReu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RRNombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RREsta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespoReu", x => x.IdResReu);
                });

            migrationBuilder.CreateTable(
                name: "ReunionDia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Division = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Responsable = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Codigoequipo = table.Column<string>(name: "Codigo_equipo", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Discrepancia = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Codigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Plandeaccion = table.Column<string>(name: "Plan_de_accion", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Tiempo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AfectadoKsf = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Produfin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrdenTrabajo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Fecha = table.Column<DateTime>(type: "date", nullable: true),
                    Fechatrab = table.Column<DateTime>(name: "Fecha_trab", type: "date", nullable: true),
                    Div = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Fecha2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Fechatrab1 = table.Column<string>(name: "Fecha_trab1", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BD_Div1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReuParM",
                columns: table => new
                {
                    IdReuParM = table.Column<int>(type: "int", nullable: false, comment: "identificador")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RPArea = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true, comment: "area en la que se realizo la parada planificada"),
                    RPFechaReu = table.Column<DateTime>(type: "date", nullable: true, comment: "fecha de la reunion"),
                    RPFechaPar = table.Column<DateTime>(type: "date", nullable: true, comment: "fecha de la parada planificada"),
                    RPMaquina = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true, comment: "maquina de la parada programada"),
                    RPNumAct = table.Column<int>(type: "int", nullable: true, comment: "numero actividades de la parada"),
                    RPTipReu = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true, comment: "tipo de reunion"),
                    RPTiePar = table.Column<double>(type: "float", nullable: true, comment: "tiempo de la parada planificada"),
                    RPAsunSPA = table.Column<int>(type: "int", nullable: true, comment: "asuntos tratados en el SPA"),
                    RPPorce = table.Column<double>(type: "float", nullable: true, comment: "Porcentaje de asistencia")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReuParM", x => x.IdReuParM);
                },
                comment: "reuniones de paradas por mantenimiento");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RNombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    REstado = table.Column<bool>(type: "bit", nullable: false),
                    RDescri = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "RspnsblP",
                columns: table => new
                {
                    IdRspnsblP = table.Column<int>(type: "int", nullable: false, comment: "Identificador del cliente del proyecto")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RPNombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, comment: "nombre del responsable"),
                    RPEstatus = table.Column<bool>(type: "bit", nullable: false, comment: "estatus(0:inactivo,1:activo)"),
                    RPUsuario = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RspnsblP", x => x.IdRspnsblP);
                },
                comment: "Responsable del proyecto");

            migrationBuilder.CreateTable(
                name: "TecniCa",
                columns: table => new
                {
                    IdTecniCa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TCNom = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    TCFicha = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TCUsuW = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    TCEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecniCa", x => x.IdTecniCa);
                },
                comment: "tecnicos de calidad");

            migrationBuilder.CreateTable(
                name: "TiParTP",
                columns: table => new
                {
                    IdTiParTP = table.Column<int>(type: "int", nullable: false, comment: "identificador")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TPCodigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "codigo del tipo parada"),
                    TPNombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, comment: "nombre del centro"),
                    TPEstado = table.Column<bool>(type: "bit", nullable: false, comment: "0: Inactivo, 1:Activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiParTP", x => x.IdTiParTP);
                },
                comment: "tipo de parada del tiempo perdido");

            migrationBuilder.CreateTable(
                name: "TipSuple",
                columns: table => new
                {
                    IdTipSuple = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TSCodigo = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    TSDescri = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    TSEstado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipSuple__9ECDEC913F95291A", x => x.IdTipSuple);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false, comment: "Identificador del usuario")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsNombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, comment: "nombre del usuario"),
                    UsEstatus = table.Column<bool>(type: "bit", nullable: false, comment: "estatus(0:inactivo,1:activo)"),
                    UsClave = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    UsCorreo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UsApellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UsUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UsFicha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UsPass = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                },
                comment: "Responsable del proyecto");

            migrationBuilder.CreateTable(
                name: "VarCa",
                columns: table => new
                {
                    IdVarCa = table.Column<int>(type: "int", nullable: false, comment: "identificador de la variable de calidad")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VCNom = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "nombre de la variable"),
                    VCDetalle = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true, comment: "Detalle de la variable"),
                    VCIsobser = table.Column<bool>(type: "bit", nullable: false, comment: "0: no de tipo observable 1:es de tipo numerico"),
                    VCEstado = table.Column<bool>(type: "bit", nullable: false, comment: "0: Inactivo, 1:Activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarCa", x => x.IdVarCa);
                },
                comment: "variable de calidad auditadas");

            migrationBuilder.CreateTable(
                name: "AsistenReu",
                columns: table => new
                {
                    IdAsistencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ARArea = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ARFecha = table.Column<DateTime>(type: "date", nullable: true),
                    ARIdCargoR = table.Column<int>(type: "int", nullable: false),
                    ArAsistente = table.Column<int>(type: "int", nullable: false),
                    ArObser = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistenReu", x => x.IdAsistencia);
                    table.ForeignKey(
                        name: "FK_AsistenReu_CargoReu",
                        column: x => x.ARIdCargoR,
                        principalTable: "CargoReu",
                        principalColumn: "IdCargoR");
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    ENombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EDescri = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    EEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.IdEmpresa);
                    table.ForeignKey(
                        name: "FK_Empresa_Pais",
                        column: x => x.IdPais,
                        principalTable: "Pais",
                        principalColumn: "IdPais");
                });

            migrationBuilder.CreateTable(
                name: "AreaTra",
                columns: table => new
                {
                    IdAreaTra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlanta = table.Column<int>(type: "int", nullable: true),
                    ATCodBPC = table.Column<int>(type: "int", nullable: true),
                    ATNombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ATCodigo = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    ATEstado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AreaTra__487F56B804138E4C", x => x.IdAreaTra);
                    table.ForeignKey(
                        name: "FK__AreaTra__IdPlant__5D2BD0E6",
                        column: x => x.IdPlanta,
                        principalTable: "Planta",
                        principalColumn: "IdPlanta");
                });

            migrationBuilder.CreateTable(
                name: "AsisPM",
                columns: table => new
                {
                    IdAsisPM = table.Column<int>(type: "int", nullable: false, comment: "identificador")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCargoPM = table.Column<int>(type: "int", nullable: false, comment: "identificador  CargoPM"),
                    IdReuParM = table.Column<int>(type: "int", nullable: false, comment: "identificador ReuParM"),
                    AIsAsis = table.Column<bool>(type: "bit", nullable: false, comment: "1: Asistencia, 0: Inasistencia")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsisPM", x => x.IdAsisPM);
                    table.ForeignKey(
                        name: "FK_AsisPM_CargoPM",
                        column: x => x.IdCargoPM,
                        principalTable: "CargoPM",
                        principalColumn: "IdCargoPM");
                    table.ForeignKey(
                        name: "FK_AsisPM_ReuParM",
                        column: x => x.IdReuParM,
                        principalTable: "ReuParM",
                        principalColumn: "IdReuParM");
                },
                comment: "reuniones de paradas por mantenimiento");

            migrationBuilder.CreateTable(
                name: "Proyecto",
                schema: "his",
                columns: table => new
                {
                    IdProyecto = table.Column<int>(type: "int", nullable: false, comment: "Identificador del proyecto")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClienteP = table.Column<int>(type: "int", nullable: false, comment: "identificador del cliente"),
                    IdRspnsblP = table.Column<int>(type: "int", nullable: false, comment: "identificador del responsable"),
                    PFechaS = table.Column<DateTime>(type: "date", nullable: false, comment: "fecha de la solicitud"),
                    PFechai = table.Column<DateTime>(type: "date", nullable: true, comment: "fecha de inicio del poyecto"),
                    PFechaC = table.Column<DateTime>(type: "date", nullable: true, comment: "fecha del cierre del proyecto"),
                    PNombre = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "nombre del proyecto"),
                    PDetalle = table.Column<string>(type: "varchar(800)", unicode: false, maxLength: 800, nullable: true, comment: "detalle del proyecto"),
                    PIsEncue = table.Column<bool>(type: "bit", nullable: false, comment: "0:no se ha realizado la encuesta, 1: se realizo"),
                    PNota = table.Column<double>(type: "float", nullable: true, comment: "nota de la encuesta"),
                    PFechaP = table.Column<DateTime>(type: "date", nullable: true, comment: "fecha programada")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.IdProyecto);
                    table.ForeignKey(
                        name: "FK_Proyecto_ClienteP",
                        column: x => x.IdClienteP,
                        principalTable: "ClienteP",
                        principalColumn: "IdClienteP");
                    table.ForeignKey(
                        name: "FK_Proyecto_RspnsblP",
                        column: x => x.IdRspnsblP,
                        principalTable: "RspnsblP",
                        principalColumn: "IdRspnsblP");
                },
                comment: "Proyecto de Mejora Continua");

            migrationBuilder.CreateTable(
                name: "ParaTP",
                columns: table => new
                {
                    IdParaTP = table.Column<int>(type: "int", nullable: false, comment: "identificador de la parada")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTiParTP = table.Column<int>(type: "int", nullable: false, comment: "identificador del tipo de la parada"),
                    PCodigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "codigo de la parada"),
                    PNombre = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false, comment: "nombre de la parada"),
                    PEstado = table.Column<bool>(type: "bit", nullable: false, comment: "0: Inactivo, 1:Activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParaTP", x => x.IdParaTP);
                    table.ForeignKey(
                        name: "FK_ParaTP_TiParTP",
                        column: x => x.IdTiParTP,
                        principalTable: "TiParTP",
                        principalColumn: "IdTiParTP");
                },
                comment: "Paradas de la linia");

            migrationBuilder.CreateTable(
                name: "TiPaPar",
                columns: table => new
                {
                    IdTiPaPar = table.Column<int>(type: "int", nullable: false, comment: "identificador del TiPa_Par")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTiParTP = table.Column<int>(type: "int", nullable: false, comment: "identificador de tipo de parada"),
                    IdParte = table.Column<int>(type: "int", nullable: false, comment: "identifiacador de la parte")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiPaPar", x => x.IdTiPaPar);
                    table.ForeignKey(
                        name: "FK_TiPaPar_Parte",
                        column: x => x.IdParte,
                        principalTable: "Parte",
                        principalColumn: "IdParte");
                    table.ForeignKey(
                        name: "FK_TiPaPar_TiParTP",
                        column: x => x.IdTiParTP,
                        principalTable: "TiParTP",
                        principalColumn: "IdTiParTP");
                },
                comment: "intermediario entre el tipo de parada y la parte");

            migrationBuilder.CreateTable(
                name: "Resumen",
                columns: table => new
                {
                    IdResumen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipSuple = table.Column<int>(type: "int", nullable: true),
                    RFecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    RTurno = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    RGrupo = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    RPlanta = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AreaTra = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RPuesto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RIsSplncia = table.Column<bool>(type: "bit", nullable: true),
                    RTrabajado = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    RTraFicha = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    RSuplido = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    RSupFicha = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resumen__C15B26E506657487", x => x.IdResumen);
                    table.ForeignKey(
                        name: "FK__Resumen__IdTipSu__5E1FF51F",
                        column: x => x.IdTipSuple,
                        principalTable: "TipSuple",
                        principalColumn: "IdTipSuple");
                });

            migrationBuilder.CreateTable(
                name: "VarAre",
                columns: table => new
                {
                    IdVarAre = table.Column<int>(type: "int", nullable: false, comment: "identificador de la Var_Are")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVarCa = table.Column<int>(type: "int", nullable: false, comment: "identificador de la variable de calidad"),
                    IdArea = table.Column<int>(type: "int", nullable: false, comment: "identifiacador del area")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarAre", x => x.IdVarAre);
                    table.ForeignKey(
                        name: "FK_VarAre_Area",
                        column: x => x.IdArea,
                        principalTable: "Area",
                        principalColumn: "IdArea");
                    table.ForeignKey(
                        name: "FK_VarAre_VarCa",
                        column: x => x.IdVarCa,
                        principalTable: "VarCa",
                        principalColumn: "IdVarCa");
                },
                comment: "intermediario entre vareable de calidad y area");

            migrationBuilder.CreateTable(
                name: "Centro",
                columns: table => new
                {
                    IdCentro = table.Column<int>(type: "int", nullable: false, comment: "identificador del centro")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNom = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "nombre del centro"),
                    CDetalle = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true, comment: "Detalle del centro"),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true),
                    CEstado = table.Column<bool>(type: "bit", nullable: false, comment: "0: Inactivo, 1:Activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centro", x => x.IdCentro);
                    table.ForeignKey(
                        name: "FK_Centro_Empresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "IdEmpresa");
                },
                comment: "centro de produccion");

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    IdPersonal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAreaTra = table.Column<int>(type: "int", nullable: true),
                    IdPuesto = table.Column<int>(type: "int", nullable: true),
                    PeNombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PeApellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PeFicha = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    PeEstado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personal__05A9201B1DEC2386", x => x.IdPersonal);
                    table.ForeignKey(
                        name: "FK__Personal__IdArea__5B438874",
                        column: x => x.IdAreaTra,
                        principalTable: "AreaTra",
                        principalColumn: "IdAreaTra");
                    table.ForeignKey(
                        name: "FK__Personal__IdPues__5C37ACAD",
                        column: x => x.IdPuesto,
                        principalTable: "Puesto",
                        principalColumn: "IdPuesto");
                });

            migrationBuilder.CreateTable(
                name: "RespP",
                columns: table => new
                {
                    IdRespP = table.Column<int>(type: "int", nullable: false, comment: "Identificador de la respuesta del proyecto")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPregP = table.Column<int>(type: "int", nullable: false, comment: "identificador de la pregunta del proyecto"),
                    IdProyecto = table.Column<int>(type: "int", nullable: false, comment: "identificador del proyecto"),
                    RPCumpli = table.Column<double>(type: "float", nullable: false, comment: "nota de la pregunta"),
                    RPObserv = table.Column<string>(type: "varchar(800)", unicode: false, maxLength: 800, nullable: true, comment: "observacion de la pregunta")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespP", x => x.IdRespP);
                    table.ForeignKey(
                        name: "FK_RespP_PregP",
                        column: x => x.IdPregP,
                        principalTable: "PregP",
                        principalColumn: "IdPregP");
                    table.ForeignKey(
                        name: "FK_RespP_Proyecto",
                        column: x => x.IdProyecto,
                        principalSchema: "his",
                        principalTable: "Proyecto",
                        principalColumn: "IdProyecto");
                },
                comment: "Respuesta de las preguntas por proyectos");

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    IdDivision = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCentro = table.Column<int>(type: "int", nullable: true),
                    DNombre = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DDetalle = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DEstado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.IdDivision);
                    table.ForeignKey(
                        name: "FK_Division_Centro",
                        column: x => x.IdCentro,
                        principalTable: "Centro",
                        principalColumn: "IdCentro");
                });

            migrationBuilder.CreateTable(
                name: "Linea",
                columns: table => new
                {
                    IdLinea = table.Column<int>(type: "int", nullable: false, comment: "identificador de la linea")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCentro = table.Column<int>(type: "int", nullable: false, comment: "identificador del centro"),
                    IdDivision = table.Column<int>(type: "int", nullable: true),
                    LNom = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "nombre de la linea"),
                    LDetalle = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true, comment: "Detalle de la linea"),
                    LEstado = table.Column<bool>(type: "bit", nullable: false, comment: "0: Inactivo, 1:Activo"),
                    LCenCos = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LOFIC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linea", x => x.IdLinea);
                    table.ForeignKey(
                        name: "FK_Linea_Centro",
                        column: x => x.IdCentro,
                        principalTable: "Centro",
                        principalColumn: "IdCentro");
                    table.ForeignKey(
                        name: "FK_Linea_Division",
                        column: x => x.IdDivision,
                        principalTable: "Division",
                        principalColumn: "IdDivision");
                },
                comment: "linea de produccion");

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    IdNivel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProyecto = table.Column<int>(type: "int", nullable: false),
                    IdDivision = table.Column<int>(type: "int", nullable: true),
                    IdRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.IdNivel);
                    table.ForeignKey(
                        name: "FK_Nivel_Division",
                        column: x => x.IdDivision,
                        principalTable: "Division",
                        principalColumn: "IdDivision");
                    table.ForeignKey(
                        name: "FK_Nivel_ProyectoUsr",
                        column: x => x.IdProyecto,
                        principalTable: "ProyectoUsr",
                        principalColumn: "IdProyecto");
                    table.ForeignKey(
                        name: "FK_Nivel_Rol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol");
                    table.ForeignKey(
                        name: "FK_Nivel_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "LibroNove",
                columns: table => new
                {
                    IdlibrNov = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLinea = table.Column<int>(type: "int", nullable: false),
                    IdEquipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LNDiscrepa = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    LNTiePerMi = table.Column<double>(type: "float", nullable: false),
                    LNFichaRes = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LNFecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    LNGrupo = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    LNTurno = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    IdMaquina = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdTipoNove = table.Column<int>(type: "int", nullable: false),
                    IdAreaCar = table.Column<int>(type: "int", nullable: false),
                    LNObserv = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    IdParada = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LNIsPizUni = table.Column<bool>(type: "bit", nullable: false),
                    IdCTPM = table.Column<int>(type: "int", nullable: true),
                    LNIsResu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroNovedades", x => x.IdlibrNov);
                    table.ForeignKey(
                        name: "FK_LibroNove_Centro",
                        column: x => x.IdAreaCar,
                        principalTable: "Centro",
                        principalColumn: "IdCentro");
                    table.ForeignKey(
                        name: "FK_LibroNove_ClasifiTPM",
                        column: x => x.IdCTPM,
                        principalTable: "ClasifiTPM",
                        principalColumn: "IdCTPM");
                    table.ForeignKey(
                        name: "FK_LibroNove_Linea",
                        column: x => x.IdLinea,
                        principalTable: "Linea",
                        principalColumn: "IdLinea");
                    table.ForeignKey(
                        name: "FK_LibroNove_TiParTP",
                        column: x => x.IdTipoNove,
                        principalTable: "TiParTP",
                        principalColumn: "IdTiParTP");
                });

            migrationBuilder.CreateTable(
                name: "LinAre",
                columns: table => new
                {
                    IdLinAre = table.Column<int>(type: "int", nullable: false, comment: "Identificador")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLinea = table.Column<int>(type: "int", nullable: false, comment: "Codigo de la linea con area"),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    LACodigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "Codigo de la linea con area")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinAre", x => x.IdLinAre);
                    table.ForeignKey(
                        name: "FK_LinAre_Area",
                        column: x => x.IdArea,
                        principalTable: "Area",
                        principalColumn: "IdArea");
                    table.ForeignKey(
                        name: "FK_LinAre_Linea",
                        column: x => x.IdLinea,
                        principalTable: "Linea",
                        principalColumn: "IdLinea");
                },
                comment: "ntermediario entre linea y area");

            migrationBuilder.CreateTable(
                name: "LinPro",
                columns: table => new
                {
                    IdLinPro = table.Column<int>(type: "int", nullable: false, comment: "identificador de la Lin_Pro")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLinea = table.Column<int>(type: "int", nullable: false, comment: "identificador de la linea"),
                    IdProducto = table.Column<int>(type: "int", nullable: false, comment: "identificador del producto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinPro", x => x.IdLinPro);
                    table.ForeignKey(
                        name: "FK_LinPro_Linea",
                        column: x => x.IdLinea,
                        principalTable: "Linea",
                        principalColumn: "IdLinea");
                    table.ForeignKey(
                        name: "FK_LinPro_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto");
                },
                comment: "intermediario entre linea y producto");

            migrationBuilder.CreateTable(
                name: "TurnoTP",
                columns: table => new
                {
                    IdTurnoTP = table.Column<int>(type: "int", nullable: false, comment: "identificador del turno")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLinea = table.Column<int>(type: "int", nullable: false, comment: "identificador de la linea"),
                    IdOperador = table.Column<int>(type: "int", nullable: false, comment: "identificador del operador"),
                    Tturno = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, comment: "turno en curso"),
                    TFecha = table.Column<DateTime>(type: "datetime", nullable: true, comment: "fecha del turno"),
                    TTrabajado = table.Column<double>(type: "float", nullable: true, comment: "tiempo trabajo del turno"),
                    TPerdido = table.Column<double>(type: "float", nullable: true, comment: "tiempo perdido del turno"),
                    TPBueno = table.Column<int>(type: "int", nullable: true, comment: "productos buenos del turno"),
                    TPMalo = table.Column<int>(type: "int", nullable: true, comment: "productos malos del turno"),
                    TVelocidad = table.Column<double>(type: "float", nullable: true, comment: "velocidad promedio del turno"),
                    TRendi = table.Column<double>(type: "float", nullable: true, comment: "rendimiento del turno"),
                    TCalidad = table.Column<double>(type: "float", nullable: true, comment: "calidad del turno"),
                    TDispo = table.Column<double>(type: "float", nullable: true, comment: "disponibilidad del turno"),
                    TOEE = table.Column<double>(type: "float", nullable: true, comment: "OEE del turno")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoTP", x => x.IdTurnoTP);
                    table.ForeignKey(
                        name: "FK_TurnoTP_Linea",
                        column: x => x.IdLinea,
                        principalTable: "Linea",
                        principalColumn: "IdLinea");
                    table.ForeignKey(
                        name: "FK_TurnoTP_Operador",
                        column: x => x.IdOperador,
                        principalTable: "Operador",
                        principalColumn: "IdOperador");
                },
                comment: "turnos de tiempo perdido");

            migrationBuilder.CreateTable(
                name: "AudCa",
                schema: "his",
                columns: table => new
                {
                    IdAudCa = table.Column<int>(type: "int", nullable: false, comment: "Identificador de la auditoria de calidad")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTecniCa = table.Column<int>(type: "int", nullable: false, comment: "identificador del tecnico"),
                    IdArea = table.Column<int>(type: "int", nullable: false, comment: "identificador del area"),
                    ACCodiPro = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "codigo del producto"),
                    ACFicSuper = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "ficha del supervisor"),
                    ACFicOper = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "ficha del operador"),
                    ACFecha = table.Column<DateTime>(type: "datetime", nullable: false, comment: "fecha de la auditoria"),
                    ACGrupo = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, comment: "grupo de la auditoria"),
                    ACTurno = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, comment: "turno de la aditoria"),
                    ACObserv = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false, comment: "observaciones dispuestas en la auditoria"),
                    ACisCamPro = table.Column<bool>(type: "bit", nullable: false, comment: "0: No es un cambio de producto; 1: cambio de producto"),
                    ACisTecn = table.Column<bool>(type: "bit", nullable: false, comment: "0: auditoria operador, 1: tecnico de calidad"),
                    ACLote = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true, comment: "lote del producto"),
                    ACPresentacion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true, comment: "presentacion del producto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudCa", x => x.IdAudCa);
                    table.ForeignKey(
                        name: "FK_AudCa_LinAre",
                        column: x => x.IdArea,
                        principalTable: "LinAre",
                        principalColumn: "IdLinAre");
                    table.ForeignKey(
                        name: "FK_AudCa_TecniCa",
                        column: x => x.IdTecniCa,
                        principalTable: "TecniCa",
                        principalColumn: "IdTecniCa");
                },
                comment: "historico de auditorias de calidad");

            migrationBuilder.CreateTable(
                name: "ParAre",
                columns: table => new
                {
                    IdParAre = table.Column<int>(type: "int", nullable: false, comment: "identificador del Par_Are")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArea = table.Column<int>(type: "int", nullable: false, comment: "identificador del area"),
                    IdParte = table.Column<int>(type: "int", nullable: false, comment: "identifiacador de la parte"),
                    PACodigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "codigo de la parte correspondiente al area		")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParAre", x => x.IdParAre);
                    table.ForeignKey(
                        name: "FK_ParAre_LinAre",
                        column: x => x.IdArea,
                        principalTable: "LinAre",
                        principalColumn: "IdLinAre");
                    table.ForeignKey(
                        name: "FK_ParAre_Parte",
                        column: x => x.IdParte,
                        principalTable: "Parte",
                        principalColumn: "IdParte");
                },
                comment: "intermediario entre la parte y el area");

            migrationBuilder.CreateTable(
                name: "ParsiOEE",
                schema: "his",
                columns: table => new
                {
                    IdParsiOEE = table.Column<int>(type: "int", nullable: false, comment: "identificador del turno")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTurnoTP = table.Column<int>(type: "int", nullable: false, comment: "identificador del turno en curso"),
                    IdArea = table.Column<int>(type: "int", nullable: false, comment: "identificador de la linea"),
                    PTrabajado = table.Column<double>(type: "float", nullable: true, comment: "tiempo trabajo del turno"),
                    PPerdido = table.Column<double>(type: "float", nullable: true, comment: "tiempo perdido del turno"),
                    PPBueno = table.Column<int>(type: "int", nullable: true, comment: "productos buenos del turno"),
                    PPMalo = table.Column<int>(type: "int", nullable: true, comment: "productos malos del turno"),
                    PVelocidad = table.Column<double>(type: "float", nullable: true, comment: "velocidad promedio del turno"),
                    PRendi = table.Column<double>(type: "float", nullable: true, comment: "rendimiento del turno"),
                    PCalidad = table.Column<double>(type: "float", nullable: true, comment: "calidad del turno"),
                    PDispo = table.Column<double>(type: "float", nullable: true, comment: "disponibilidad del turno"),
                    POEE = table.Column<double>(type: "float", nullable: true, comment: "OEE del turno")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParsiOEE", x => x.IdParsiOEE);
                    table.ForeignKey(
                        name: "FK_ParsiOEE_LinAre",
                        column: x => x.IdArea,
                        principalTable: "LinAre",
                        principalColumn: "IdLinAre");
                    table.ForeignKey(
                        name: "FK_ParsiOEE_TurnoTP",
                        column: x => x.IdTurnoTP,
                        principalTable: "TurnoTP",
                        principalColumn: "IdTurnoTP");
                },
                comment: "datos obteneidos de un area especifico del turno en curso");

            migrationBuilder.CreateTable(
                name: "TurPro",
                columns: table => new
                {
                    IdTurPro = table.Column<int>(type: "int", nullable: false, comment: "identificador de la Tur_Pro")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTurnoTP = table.Column<int>(type: "int", nullable: false, comment: "identificador del turno"),
                    IdProducto = table.Column<int>(type: "int", nullable: false, comment: "identificador del producto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurPro", x => x.IdTurPro);
                    table.ForeignKey(
                        name: "FK_TurPro_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto");
                    table.ForeignKey(
                        name: "FK_TurPro_TurnoTP",
                        column: x => x.IdTurnoTP,
                        principalTable: "TurnoTP",
                        principalColumn: "IdTurnoTP");
                },
                comment: "intermediario entre turno del tiempo perdido y producto");

            migrationBuilder.CreateTable(
                name: "DatAudCa",
                columns: table => new
                {
                    IdDatAudCa = table.Column<int>(type: "int", nullable: false, comment: "Identificador del dato")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVarCa = table.Column<int>(type: "int", nullable: false, comment: "identificador de la variable"),
                    IdAudCa = table.Column<int>(type: "int", nullable: false, comment: "identificador de la auditoria"),
                    DACValor = table.Column<double>(type: "float", nullable: false, comment: "valor observado"),
                    DACIsAcep = table.Column<bool>(type: "bit", nullable: true, comment: "0: no aceptable, 1:aceptable")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatAudCa", x => x.IdDatAudCa);
                    table.ForeignKey(
                        name: "FK_DatAudCa_AudCa",
                        column: x => x.IdAudCa,
                        principalSchema: "his",
                        principalTable: "AudCa",
                        principalColumn: "IdAudCa");
                    table.ForeignKey(
                        name: "FK_DatAudCa_VarCa",
                        column: x => x.IdVarCa,
                        principalTable: "VarCa",
                        principalColumn: "IdVarCa");
                },
                comment: "data de la auditoria");

            migrationBuilder.CreateTable(
                name: "TieEjeTP",
                columns: table => new
                {
                    IdTieEjeTP = table.Column<int>(type: "int", nullable: false, comment: "identificador del tiempo ejecutado de un turno")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdParsiOEE = table.Column<int>(type: "int", nullable: false, comment: "identificador del turno"),
                    TEFechai = table.Column<DateTime>(type: "datetime", nullable: false, comment: "fecha de inicio del tiempo ejecutado"),
                    TEFechaf = table.Column<DateTime>(type: "datetime", nullable: true, comment: "fecha final del tiempo ejecutado"),
                    TEDuracion = table.Column<double>(type: "float", nullable: true, comment: "duracion del tiempo ejecutado"),
                    TEVelocidad = table.Column<double>(type: "float", nullable: true, comment: "velocidad promedio"),
                    TEBueno = table.Column<int>(type: "int", nullable: true, comment: "cantidad de productos buenos"),
                    TEMalo = table.Column<int>(type: "int", nullable: true, comment: "cantidad de productos malos"),
                    TENumVuelt = table.Column<int>(type: "int", nullable: true),
                    TEProducidos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TieEjeTP", x => x.IdTieEjeTP);
                    table.ForeignKey(
                        name: "FK_TieEjeTP_ParsiOEE",
                        column: x => x.IdParsiOEE,
                        principalSchema: "his",
                        principalTable: "ParsiOEE",
                        principalColumn: "IdParsiOEE");
                },
                comment: "tiempo ejecutado en el turno");

            migrationBuilder.CreateTable(
                name: "TieParTP",
                columns: table => new
                {
                    IdTieParTP = table.Column<int>(type: "int", nullable: false, comment: "identificador del tiempo parado de un turno")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdParsiOEE = table.Column<int>(type: "int", nullable: false, comment: "identificador del turno"),
                    IdParaTP = table.Column<int>(type: "int", nullable: false, comment: "identificador de la parada"),
                    TEFechai = table.Column<DateTime>(type: "datetime", nullable: false, comment: "fecha de inicio de la parada"),
                    TEFechaf = table.Column<DateTime>(type: "datetime", nullable: true, comment: "fecha final de la parada"),
                    TEDuracion = table.Column<double>(type: "float", nullable: true, comment: "duracion de la parada")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TieParTP", x => x.IdTieParTP);
                    table.ForeignKey(
                        name: "FK_TieParTP_ParaTP",
                        column: x => x.IdParaTP,
                        principalTable: "ParaTP",
                        principalColumn: "IdParaTP");
                    table.ForeignKey(
                        name: "FK_TieParTP_ParsiOEE",
                        column: x => x.IdParsiOEE,
                        principalSchema: "his",
                        principalTable: "ParsiOEE",
                        principalColumn: "IdParsiOEE");
                },
                comment: "tiempo parado en el turno");

            migrationBuilder.CreateIndex(
                name: "IX_AreaTra_IdPlanta",
                table: "AreaTra",
                column: "IdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_AsisPM_IdCargoPM",
                table: "AsisPM",
                column: "IdCargoPM");

            migrationBuilder.CreateIndex(
                name: "IX_AsisPM_IdReuParM",
                table: "AsisPM",
                column: "IdReuParM");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenReu_ARIdCargoR",
                table: "AsistenReu",
                column: "ARIdCargoR");

            migrationBuilder.CreateIndex(
                name: "IX_AudCa_IdArea",
                schema: "his",
                table: "AudCa",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_AudCa_IdTecniCa",
                schema: "his",
                table: "AudCa",
                column: "IdTecniCa");

            migrationBuilder.CreateIndex(
                name: "IX_Centro_IdEmpresa",
                table: "Centro",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_DatAudCa_IdAudCa",
                table: "DatAudCa",
                column: "IdAudCa");

            migrationBuilder.CreateIndex(
                name: "IX_DatAudCa_IdVarCa",
                table: "DatAudCa",
                column: "IdVarCa");

            migrationBuilder.CreateIndex(
                name: "IX_Division_IdCentro",
                table: "Division",
                column: "IdCentro");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_IdPais",
                table: "Empresa",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_LibroNove_IdAreaCar",
                table: "LibroNove",
                column: "IdAreaCar");

            migrationBuilder.CreateIndex(
                name: "IX_LibroNove_IdCTPM",
                table: "LibroNove",
                column: "IdCTPM");

            migrationBuilder.CreateIndex(
                name: "IX_LibroNove_IdLinea",
                table: "LibroNove",
                column: "IdLinea");

            migrationBuilder.CreateIndex(
                name: "IX_LibroNove_IdTipoNove",
                table: "LibroNove",
                column: "IdTipoNove");

            migrationBuilder.CreateIndex(
                name: "IX_LinAre_IdArea",
                table: "LinAre",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_LinAre_IdLinea",
                table: "LinAre",
                column: "IdLinea");

            migrationBuilder.CreateIndex(
                name: "IX_Linea_IdCentro",
                table: "Linea",
                column: "IdCentro");

            migrationBuilder.CreateIndex(
                name: "IX_Linea_IdDivision",
                table: "Linea",
                column: "IdDivision");

            migrationBuilder.CreateIndex(
                name: "IX_LinPro_IdLinea",
                table: "LinPro",
                column: "IdLinea");

            migrationBuilder.CreateIndex(
                name: "IX_LinPro_IdProducto",
                table: "LinPro",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_IdDivision",
                table: "Nivel",
                column: "IdDivision");

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_IdProyecto",
                table: "Nivel",
                column: "IdProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_IdRol",
                table: "Nivel",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_IdUsuario",
                table: "Nivel",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ParAre_IdArea",
                table: "ParAre",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_ParAre_IdParte",
                table: "ParAre",
                column: "IdParte");

            migrationBuilder.CreateIndex(
                name: "IX_ParaTP_IdTiParTP",
                table: "ParaTP",
                column: "IdTiParTP");

            migrationBuilder.CreateIndex(
                name: "IX_ParsiOEE_IdArea",
                schema: "his",
                table: "ParsiOEE",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_ParsiOEE_IdTurnoTP",
                schema: "his",
                table: "ParsiOEE",
                column: "IdTurnoTP");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_IdAreaTra",
                table: "Personal",
                column: "IdAreaTra");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_IdPuesto",
                table: "Personal",
                column: "IdPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_IdClienteP",
                schema: "his",
                table: "Proyecto",
                column: "IdClienteP");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_IdRspnsblP",
                schema: "his",
                table: "Proyecto",
                column: "IdRspnsblP");

            migrationBuilder.CreateIndex(
                name: "IX_RespP_IdPregP",
                table: "RespP",
                column: "IdPregP");

            migrationBuilder.CreateIndex(
                name: "IX_RespP_IdProyecto",
                table: "RespP",
                column: "IdProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Resumen_IdTipSuple",
                table: "Resumen",
                column: "IdTipSuple");

            migrationBuilder.CreateIndex(
                name: "IX_TieEjeTP_IdParsiOEE",
                table: "TieEjeTP",
                column: "IdParsiOEE");

            migrationBuilder.CreateIndex(
                name: "IX_TieParTP_IdParaTP",
                table: "TieParTP",
                column: "IdParaTP");

            migrationBuilder.CreateIndex(
                name: "IX_TieParTP_IdParsiOEE",
                table: "TieParTP",
                column: "IdParsiOEE");

            migrationBuilder.CreateIndex(
                name: "IX_TiPaPar_IdParte",
                table: "TiPaPar",
                column: "IdParte");

            migrationBuilder.CreateIndex(
                name: "IX_TiPaPar_IdTiParTP",
                table: "TiPaPar",
                column: "IdTiParTP");

            migrationBuilder.CreateIndex(
                name: "IX_TurnoTP_IdLinea",
                table: "TurnoTP",
                column: "IdLinea");

            migrationBuilder.CreateIndex(
                name: "IX_TurnoTP_IdOperador",
                table: "TurnoTP",
                column: "IdOperador");

            migrationBuilder.CreateIndex(
                name: "IX_TurPro_IdProducto",
                table: "TurPro",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_TurPro_IdTurnoTP",
                table: "TurPro",
                column: "IdTurnoTP");

            migrationBuilder.CreateIndex(
                name: "IX_VarAre_IdArea",
                table: "VarAre",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_VarAre_IdVarCa",
                table: "VarAre",
                column: "IdVarCa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsisPM");

            migrationBuilder.DropTable(
                name: "AsistenReu");

            migrationBuilder.DropTable(
                name: "AutenUsr");

            migrationBuilder.DropTable(
                name: "DatAudCa");

            migrationBuilder.DropTable(
                name: "KSF");

            migrationBuilder.DropTable(
                name: "LibroNove");

            migrationBuilder.DropTable(
                name: "LinPro");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "ParAre");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "RespoReu");

            migrationBuilder.DropTable(
                name: "RespP");

            migrationBuilder.DropTable(
                name: "Resumen");

            migrationBuilder.DropTable(
                name: "ReunionDia");

            migrationBuilder.DropTable(
                name: "TieEjeTP");

            migrationBuilder.DropTable(
                name: "TieParTP");

            migrationBuilder.DropTable(
                name: "TiPaPar");

            migrationBuilder.DropTable(
                name: "TurPro");

            migrationBuilder.DropTable(
                name: "VarAre");

            migrationBuilder.DropTable(
                name: "CargoPM");

            migrationBuilder.DropTable(
                name: "ReuParM");

            migrationBuilder.DropTable(
                name: "CargoReu");

            migrationBuilder.DropTable(
                name: "AudCa",
                schema: "his");

            migrationBuilder.DropTable(
                name: "ClasifiTPM");

            migrationBuilder.DropTable(
                name: "ProyectoUsr");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "AreaTra");

            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropTable(
                name: "PregP");

            migrationBuilder.DropTable(
                name: "Proyecto",
                schema: "his");

            migrationBuilder.DropTable(
                name: "TipSuple");

            migrationBuilder.DropTable(
                name: "ParaTP");

            migrationBuilder.DropTable(
                name: "ParsiOEE",
                schema: "his");

            migrationBuilder.DropTable(
                name: "Parte");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "VarCa");

            migrationBuilder.DropTable(
                name: "TecniCa");

            migrationBuilder.DropTable(
                name: "Planta");

            migrationBuilder.DropTable(
                name: "ClienteP");

            migrationBuilder.DropTable(
                name: "RspnsblP");

            migrationBuilder.DropTable(
                name: "TiParTP");

            migrationBuilder.DropTable(
                name: "LinAre");

            migrationBuilder.DropTable(
                name: "TurnoTP");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Linea");

            migrationBuilder.DropTable(
                name: "Operador");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Centro");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmileSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class agregoTipoAtencion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObrasSociales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasSociales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Odontologos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NroMatricula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odontologos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAtenciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Duracion = table.Column<TimeSpan>(type: "time", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAtenciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ObraSocialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlanes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoPlanes_ObrasSociales_ObraSocialId",
                        column: x => x.ObraSocialId,
                        principalTable: "ObrasSociales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NroDni = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NroAfiliado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NroHC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_TipoPlanes_TipoPlanId",
                        column: x => x.TipoPlanId,
                        principalTable: "TipoPlanes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Atencion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHoraAtencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdontologoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    TipoAtencionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atencion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atencion_Odontologos_OdontologoId",
                        column: x => x.OdontologoId,
                        principalTable: "Odontologos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atencion_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atencion_TipoAtenciones_TipoAtencionId",
                        column: x => x.TipoAtencionId,
                        principalTable: "TipoAtenciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_OdontologoId",
                table: "Atencion",
                column: "OdontologoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_PacienteId",
                table: "Atencion",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_TipoAtencionId",
                table: "Atencion",
                column: "TipoAtencionId");

            migrationBuilder.CreateIndex(
                name: "IX_ObrasSociales_Nombre",
                table: "ObrasSociales",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Odontologos_NroMatricula",
                table: "Odontologos",
                column: "NroMatricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_NroHC",
                table: "Pacientes",
                column: "NroHC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_TipoPlanId",
                table: "Pacientes",
                column: "TipoPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPlanes_ObraSocialId",
                table: "TipoPlanes",
                column: "ObraSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atencion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Odontologos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "TipoAtenciones");

            migrationBuilder.DropTable(
                name: "TipoPlanes");

            migrationBuilder.DropTable(
                name: "ObrasSociales");
        }
    }
}

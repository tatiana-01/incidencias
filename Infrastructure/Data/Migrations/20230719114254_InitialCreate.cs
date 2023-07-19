using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreArea = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreCategoria = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipoEmail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoIncidencia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NivelIncidencia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIncidencia", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposHardware",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreHardware = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHardware", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposSoftware",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreSoftware = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSoftware", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombreCompleto = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idArea = table.Column<int>(type: "int", nullable: false),
                    nombreSalon = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeroPuestos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Salones_Areas_idArea",
                        column: x => x.idArea,
                        principalTable: "Areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmailsTrainers",
                columns: table => new
                {
                    idTrainer = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idEmail = table.Column<int>(type: "int", nullable: false),
                    trainerEmail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsTrainers", x => new { x.idTrainer, x.idEmail });
                    table.ForeignKey(
                        name: "FK_EmailsTrainers_Emails_idEmail",
                        column: x => x.idEmail,
                        principalTable: "Emails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmailsTrainers_Trainers_idTrainer",
                        column: x => x.idTrainer,
                        principalTable: "Trainers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TelefonoTrainers",
                columns: table => new
                {
                    idTrainer = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idTelefono = table.Column<int>(type: "int", nullable: false),
                    numeroTelefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoTrainers", x => new { x.idTrainer, x.idTelefono });
                    table.ForeignKey(
                        name: "FK_TelefonoTrainers_Telefonos_idTelefono",
                        column: x => x.idTelefono,
                        principalTable: "Telefonos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelefonoTrainers_Trainers_idTrainer",
                        column: x => x.idTrainer,
                        principalTable: "Trainers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombrePuesto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idSalon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Puestos_Salones_idSalon",
                        column: x => x.idSalon,
                        principalTable: "Salones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Hardwares",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idTipoHardware = table.Column<int>(type: "int", nullable: false),
                    idPuesto = table.Column<int>(type: "int", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardwares", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hardwares_Categorias_idTipoHardware",
                        column: x => x.idTipoHardware,
                        principalTable: "Categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hardwares_Puestos_idPuesto",
                        column: x => x.idPuesto,
                        principalTable: "Puestos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hardwares_TiposHardware_idTipoHardware",
                        column: x => x.idTipoHardware,
                        principalTable: "TiposHardware",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idTipoIncidencia = table.Column<int>(type: "int", nullable: false),
                    idPuesto = table.Column<int>(type: "int", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    idTrainer = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaReporte = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.id);
                    table.ForeignKey(
                        name: "FK_Incidencias_Categorias_idCategoria",
                        column: x => x.idCategoria,
                        principalTable: "Categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_Puestos_idPuesto",
                        column: x => x.idPuesto,
                        principalTable: "Puestos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_TipoIncidencia_idTipoIncidencia",
                        column: x => x.idTipoIncidencia,
                        principalTable: "TipoIncidencia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_Trainers_idTrainer",
                        column: x => x.idTrainer,
                        principalTable: "Trainers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Softwares",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idTipoSoftware = table.Column<int>(type: "int", nullable: false),
                    idPuesto = table.Column<int>(type: "int", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.id);
                    table.ForeignKey(
                        name: "FK_Softwares_Categorias_idCategoria",
                        column: x => x.idCategoria,
                        principalTable: "Categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Softwares_Puestos_idPuesto",
                        column: x => x.idPuesto,
                        principalTable: "Puestos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Softwares_TiposSoftware_idTipoSoftware",
                        column: x => x.idTipoSoftware,
                        principalTable: "TiposSoftware",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EmailsTrainers_idEmail",
                table: "EmailsTrainers",
                column: "idEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Hardwares_idPuesto",
                table: "Hardwares",
                column: "idPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Hardwares_idTipoHardware",
                table: "Hardwares",
                column: "idTipoHardware");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_idCategoria",
                table: "Incidencias",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_idPuesto",
                table: "Incidencias",
                column: "idPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_idTipoIncidencia",
                table: "Incidencias",
                column: "idTipoIncidencia");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_idTrainer",
                table: "Incidencias",
                column: "idTrainer");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_idSalon",
                table: "Puestos",
                column: "idSalon");

            migrationBuilder.CreateIndex(
                name: "IX_Salones_idArea",
                table: "Salones",
                column: "idArea");

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_idCategoria",
                table: "Softwares",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_idPuesto",
                table: "Softwares",
                column: "idPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_idTipoSoftware",
                table: "Softwares",
                column: "idTipoSoftware");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonoTrainers_idTelefono",
                table: "TelefonoTrainers",
                column: "idTelefono");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailsTrainers");

            migrationBuilder.DropTable(
                name: "Hardwares");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "Softwares");

            migrationBuilder.DropTable(
                name: "TelefonoTrainers");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "TiposHardware");

            migrationBuilder.DropTable(
                name: "TipoIncidencia");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "TiposSoftware");

            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Salones");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}

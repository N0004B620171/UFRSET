using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFRSET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomDepartement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.DepartementId);
                });

            migrationBuilder.CreateTable(
                name: "Filiere",
                columns: table => new
                {
                    FiliereId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFiliere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.FiliereId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomService = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "DepartementFiliere",
                columns: table => new
                {
                    DepartementsDepartementId = table.Column<int>(type: "int", nullable: false),
                    FilieresFiliereId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartementFiliere", x => new { x.DepartementsDepartementId, x.FilieresFiliereId });
                    table.ForeignKey(
                        name: "FK_DepartementFiliere_Departement_DepartementsDepartementId",
                        column: x => x.DepartementsDepartementId,
                        principalTable: "Departement",
                        principalColumn: "DepartementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartementFiliere_Filiere_FilieresFiliereId",
                        column: x => x.FilieresFiliereId,
                        principalTable: "Filiere",
                        principalColumn: "FiliereId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Per",
                columns: table => new
                {
                    PerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Per", x => x.PerId);
                    table.ForeignKey(
                        name: "FK_Per_Departement_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departement",
                        principalColumn: "DepartementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Per_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacataire",
                columns: table => new
                {
                    VacataireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomVacataire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacataire", x => x.VacataireId);
                    table.ForeignKey(
                        name: "FK_Vacataire_Departement_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departement",
                        principalColumn: "DepartementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacataire_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartementFiliere_FilieresFiliereId",
                table: "DepartementFiliere",
                column: "FilieresFiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_Per_DepartementId",
                table: "Per",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Per_ServiceId",
                table: "Per",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacataire_DepartementId",
                table: "Vacataire",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacataire_ServiceId",
                table: "Vacataire",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartementFiliere");

            migrationBuilder.DropTable(
                name: "Per");

            migrationBuilder.DropTable(
                name: "Vacataire");

            migrationBuilder.DropTable(
                name: "Filiere");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}

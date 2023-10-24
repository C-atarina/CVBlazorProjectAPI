using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiCV.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfilEntities",
                columns: table => new
                {
                    Id_Profil = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Profil = table.Column<string>(type: "text", nullable: false),
                    Tel = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilEntities", x => x.Id_Profil);
                });

            migrationBuilder.CreateTable(
                name: "TypeCompetenceEntities",
                columns: table => new
                {
                    Id_TypeCompetences = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCompetenceEntities", x => x.Id_TypeCompetences);
                });

            migrationBuilder.CreateTable(
                name: "EducationEntities",
                columns: table => new
                {
                    Id_Education = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomEcole = table.Column<string>(type: "text", nullable: false),
                    Diplome = table.Column<string>(type: "text", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id_Profil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationEntities", x => x.Id_Education);
                    table.ForeignKey(
                        name: "FK_EducationEntities_ProfilEntities_Id_Profil",
                        column: x => x.Id_Profil,
                        principalTable: "ProfilEntities",
                        principalColumn: "Id_Profil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceEntities",
                columns: table => new
                {
                    Id_Experience = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom_Entreprise = table.Column<string>(type: "text", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Id_Profil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceEntities", x => x.Id_Experience);
                    table.ForeignKey(
                        name: "FK_ExperienceEntities_ProfilEntities_Id_Profil",
                        column: x => x.Id_Profil,
                        principalTable: "ProfilEntities",
                        principalColumn: "Id_Profil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetenceEntities",
                columns: table => new
                {
                    Id_Competences = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "text", nullable: false),
                    Id_TypeCompetences = table.Column<int>(type: "integer", nullable: false),
                    Id_Profil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceEntities", x => x.Id_Competences);
                    table.ForeignKey(
                        name: "FK_CompetenceEntities_ProfilEntities_Id_Profil",
                        column: x => x.Id_Profil,
                        principalTable: "ProfilEntities",
                        principalColumn: "Id_Profil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetenceEntities_TypeCompetenceEntities_Id_TypeCompetences",
                        column: x => x.Id_TypeCompetences,
                        principalTable: "TypeCompetenceEntities",
                        principalColumn: "Id_TypeCompetences",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceEntities_Id_Profil",
                table: "CompetenceEntities",
                column: "Id_Profil");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceEntities_Id_TypeCompetences",
                table: "CompetenceEntities",
                column: "Id_TypeCompetences");

            migrationBuilder.CreateIndex(
                name: "IX_EducationEntities_Id_Profil",
                table: "EducationEntities",
                column: "Id_Profil");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceEntities_Id_Profil",
                table: "ExperienceEntities",
                column: "Id_Profil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenceEntities");

            migrationBuilder.DropTable(
                name: "EducationEntities");

            migrationBuilder.DropTable(
                name: "ExperienceEntities");

            migrationBuilder.DropTable(
                name: "TypeCompetenceEntities");

            migrationBuilder.DropTable(
                name: "ProfilEntities");
        }
    }
}

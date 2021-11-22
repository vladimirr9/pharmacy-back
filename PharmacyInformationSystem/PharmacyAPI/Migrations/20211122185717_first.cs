using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PharmacyAPI.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientInMedication",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicationID = table.Column<long>(type: "bigint", nullable: false),
                    IngredientID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientInMedication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PharmacyID = table.Column<long>(type: "bigint", nullable: false),
                    MedicationID = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Usage = table.Column<string>(type: "text", nullable: true),
                    Precautions = table.Column<string>(type: "text", nullable: true),
                    PotentialDangers = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    DurationStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DurationEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjectionIdFromHospitalDatabase = table.Column<long>(type: "bigint", nullable: false),
                    HopsitalName = table.Column<string>(type: "text", nullable: true),
                    TextObjection = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Adress = table.Column<string>(type: "text", nullable: true),
                    AdressNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistratedHospitals",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    ApiKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistratedHospitals", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjectionIdFromHospitalDatabase = table.Column<long>(type: "bigint", nullable: false),
                    HospitalName = table.Column<string>(type: "text", nullable: true),
                    TextResponse = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationIngredients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MedicationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationIngredients_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "IngredientInMedication",
                columns: new[] { "Id", "IngredientID", "MedicationID" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 2L, 2L },
                    { 3L, 2L, 1L }
                });

            migrationBuilder.InsertData(
                table: "InventoryLogs",
                columns: new[] { "Id", "MedicationID", "PharmacyID", "Quantity" },
                values: new object[,]
                {
                    { 4L, 3L, 2L, 120L },
                    { 3L, 1L, 2L, 20L },
                    { 5L, 1L, 3L, 14L },
                    { 2L, 2L, 1L, 85L },
                    { 1L, 1L, 1L, 65L }
                });

            migrationBuilder.InsertData(
                table: "MedicationIngredients",
                columns: new[] { "Id", "MedicationId", "Name" },
                values: new object[,]
                {
                    { 1L, null, "Vitamin C" },
                    { 2L, null, "Phosphorus" },
                    { 3L, null, "Calcium" }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Manufacturer", "Name", "PotentialDangers", "Precautions", "Quantity", "Status", "Usage" },
                values: new object[,]
                {
                    { 1L, "J&J", "Synthroid", "None.", "None.", 150, 0, "Taken once per day" },
                    { 2L, "Merck & Co. Inc.", "Ventolin", "Not advised for pregnant women.", "None.", 200, 2, "Taken twice per day" },
                    { 3L, "Pfizer Inc.", "Januvia", "Not advised for children.", "None.", 750, 0, "Taken once once every 5 hours" }
                });

            migrationBuilder.InsertData(
                table: "Objections",
                columns: new[] { "Id", "HopsitalName", "ObjectionIdFromHospitalDatabase", "TextObjection" },
                values: new object[] { 1L, "Bolnica1", 0L, "Ne valja nista" });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "Adress", "AdressNumber", "City", "Name" },
                values: new object[,]
                {
                    { 3L, "Olge Jovanović", "18a", "Beograd", "Janković" },
                    { 2L, "Bulevar oslobođenja", "135", "Novi Sad", "Janković" },
                    { 1L, "Rumenačka", "15", "Novi Sad", "Janković" }
                });

            migrationBuilder.InsertData(
                table: "RegistratedHospitals",
                columns: new[] { "Name", "ApiKey", "Url" },
                values: new object[] { "Bolnica1", "fds15d4fs6", "http:localhost:7313" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "Id", "HospitalName", "ObjectionIdFromHospitalDatabase", "TextResponse" },
                values: new object[] { 1L, "Bolnica1", 0L, "Kleveta" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationIngredients_MedicationId",
                table: "MedicationIngredients",
                column: "MedicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientInMedication");

            migrationBuilder.DropTable(
                name: "InventoryLogs");

            migrationBuilder.DropTable(
                name: "MedicationIngredients");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Objections");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "RegistratedHospitals");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Medications");
        }
    }
}

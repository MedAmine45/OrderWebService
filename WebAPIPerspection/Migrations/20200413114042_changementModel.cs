using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIPerspection.Migrations
{
    public partial class changementModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tube",
                table: "Prescription",
                newName: "Shipped_on");

            migrationBuilder.RenameColumn(
                name: "BillingState",
                table: "Prescription",
                newName: "Payment_method");

            migrationBuilder.RenameColumn(
                name: "Analyse",
                table: "Prescription",
                newName: "Shipped_by");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount_paid",
                table: "Prescription",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Billing_state",
                table: "Prescription",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dossier_glims",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Invoice_id",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Invoice_state",
                table: "Prescription",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kit_shipping_no",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sample_shipping_no",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Person",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Person",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Person",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Birth_date",
                table: "Person",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Person",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Analyse",
                columns: table => new
                {
                    AnalyseID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Tubes = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Tube_violet = table.Column<int>(nullable: false),
                    Tube_rouge = table.Column<int>(nullable: false),
                    Tube_gris = table.Column<int>(nullable: false),
                    Urine_matin = table.Column<int>(nullable: false),
                    Selles = table.Column<int>(nullable: false),
                    PrescriptionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyse", x => x.AnalyseID);
                    table.ForeignKey(
                        name: "FK_Analyse_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    LogID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    State = table.Column<string>(nullable: true),
                    Billing_state = table.Column<string>(nullable: true),
                    Invoice_state = table.Column<string>(nullable: true),
                    By = table.Column<string>(nullable: false),
                    On = table.Column<DateTime>(nullable: false),
                    PrescriptionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_Log_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyse_PrescriptionId",
                table: "Analyse",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_PrescriptionId",
                table: "Log",
                column: "PrescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analyse");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropColumn(
                name: "Amount_paid",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Billing_state",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Dossier_glims",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Invoice_id",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Invoice_state",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Kit_shipping_no",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Sample_shipping_no",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "Shipped_on",
                table: "Prescription",
                newName: "Tube");

            migrationBuilder.RenameColumn(
                name: "Shipped_by",
                table: "Prescription",
                newName: "Analyse");

            migrationBuilder.RenameColumn(
                name: "Payment_method",
                table: "Prescription",
                newName: "BillingState");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Person",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Person",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Birth_date",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

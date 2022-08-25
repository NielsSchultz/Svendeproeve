using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionSyd.Repositories.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "JournalEntryID",
                keyValue: 1,
                column: "LastEdited",
                value: new DateTime(2022, 8, 25, 13, 52, 15, 913, DateTimeKind.Utc).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "JournalEntryID",
                keyValue: 2,
                column: "LastEdited",
                value: new DateTime(2022, 8, 25, 13, 52, 15, 913, DateTimeKind.Utc).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "JournalEntryID",
                keyValue: 3,
                column: "LastEdited",
                value: new DateTime(2022, 8, 25, 13, 52, 15, 913, DateTimeKind.Utc).AddTicks(92));

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_DepartmentID",
                table: "JournalEntry",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_TreatmentPlaceID",
                table: "JournalEntry",
                column: "TreatmentPlaceID");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_Department_DepartmentID",
                table: "JournalEntry",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_TreatmentPlace_TreatmentPlaceID",
                table: "JournalEntry",
                column: "TreatmentPlaceID",
                principalTable: "TreatmentPlace",
                principalColumn: "TreatmentPlaceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_Department_DepartmentID",
                table: "JournalEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_TreatmentPlace_TreatmentPlaceID",
                table: "JournalEntry");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntry_DepartmentID",
                table: "JournalEntry");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntry_TreatmentPlaceID",
                table: "JournalEntry");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "JournalEntryID",
                keyValue: 1,
                column: "LastEdited",
                value: new DateTime(2022, 8, 25, 13, 46, 46, 907, DateTimeKind.Utc).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "JournalEntryID",
                keyValue: 2,
                column: "LastEdited",
                value: new DateTime(2022, 8, 25, 13, 46, 46, 907, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "JournalEntryID",
                keyValue: 3,
                column: "LastEdited",
                value: new DateTime(2022, 8, 25, 13, 46, 46, 907, DateTimeKind.Utc).AddTicks(6363));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceLayer.Migrations
{
    public partial class addedtagstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1,
                column: "InsertedDate",
                value: new DateTime(2021, 1, 26, 18, 45, 48, 663, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2,
                column: "InsertedDate",
                value: new DateTime(2021, 1, 26, 18, 45, 48, 668, DateTimeKind.Local).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3,
                column: "InsertedDate",
                value: new DateTime(2021, 1, 26, 18, 45, 48, 668, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4,
                column: "InsertedDate",
                value: new DateTime(2021, 1, 26, 18, 45, 48, 668, DateTimeKind.Local).AddTicks(4821));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 26, 9, 20, 38, 971, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 26, 9, 20, 38, 975, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 26, 9, 20, 38, 975, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 26, 9, 20, 38, 975, DateTimeKind.Local).AddTicks(1175));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceLayer.Migrations
{
    public partial class changedatetimereleasetostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Released",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Released",
                value: "2006/12/18");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Released",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 22, 22, 7, 46, 728, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 22, 22, 7, 46, 733, DateTimeKind.Local).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 22, 22, 7, 46, 733, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 22, 22, 7, 46, 733, DateTimeKind.Local).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Released",
                value: new DateTime(2020, 8, 22, 22, 7, 46, 734, DateTimeKind.Local).AddTicks(3060));
        }
    }
}

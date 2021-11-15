using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceLayer.Migrations
{
    public partial class changed_movie_table1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternateName",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YouTubeLink",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Actors",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternateName",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "YouTubeLink",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Actors");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 18, 21, 42, 37, 600, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 18, 21, 42, 37, 604, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 18, 21, 42, 37, 604, DateTimeKind.Local).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 18, 21, 42, 37, 604, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Released",
                value: new DateTime(2020, 8, 18, 21, 42, 37, 604, DateTimeKind.Local).AddTicks(6777));
        }
    }
}

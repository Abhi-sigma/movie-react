using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceLayer.Migrations
{
    public partial class changedmoviesstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Actors",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Awards",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Released",
                table: "Movies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "imdbId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "imdbrating",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 15, 23, 2, 50, 612, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(2571));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 5,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 6,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                columns: new[] { "Released", "Title", "imdbrating" },
                values: new object[] { new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(5791), "Kalyanam", 4 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                columns: new[] { "Released", "Title", "imdbrating" },
                values: new object[] { new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(7074), "Don", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actors",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Awards",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Plot",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Released",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "imdbId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "imdbrating",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 11, 8, 37, 58, 367, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 11, 8, 37, 58, 372, DateTimeKind.Local).AddTicks(416));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 11, 8, 37, 58, 372, DateTimeKind.Local).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 11, 8, 37, 58, 372, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 5,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 11, 8, 37, 58, 372, DateTimeKind.Local).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 6,
                column: "InsertedDate",
                value: new DateTime(2020, 8, 11, 8, 37, 58, 372, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                columns: new[] { "Name", "Rating", "ReleaseDate" },
                values: new object[] { "Kalyanam", 4, new DateTime(2020, 8, 11, 8, 37, 58, 372, DateTimeKind.Local).AddTicks(3808) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                columns: new[] { "Name", "Rating", "ReleaseDate" },
                values: new object[] { "Don", 5, new DateTime(2020, 8, 11, 8, 37, 58, 372, DateTimeKind.Local).AddTicks(5557) });
        }
    }
}

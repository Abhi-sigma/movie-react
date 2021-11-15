using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceLayer.Migrations
{
    public partial class changed_movie_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Actors");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Actors",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ActorTypes",
                columns: new[] { "ActorTypeId", "Name" },
                values: new object[] { 2, "Actress" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1,
                columns: new[] { "InsertedDate", "Name" },
                values: new object[] { new DateTime(2020, 8, 18, 21, 42, 37, 600, DateTimeKind.Local).AddTicks(1088), "Allu Arjun" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2,
                columns: new[] { "InsertedDate", "Name" },
                values: new object[] { new DateTime(2020, 8, 18, 21, 42, 37, 604, DateTimeKind.Local).AddTicks(3320), "Ravi Teja" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3,
                columns: new[] { "InsertedDate", "Name" },
                values: new object[] { new DateTime(2020, 8, 18, 21, 42, 37, 604, DateTimeKind.Local).AddTicks(3523), "Shree Ram" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4,
                columns: new[] { "InsertedDate", "Name" },
                values: new object[] { new DateTime(2020, 8, 18, 21, 42, 37, 604, DateTimeKind.Local).AddTicks(3531), "Jnr Ntr" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Released",
                value: new DateTime(2020, 8, 18, 21, 42, 37, 604, DateTimeKind.Local).AddTicks(6777));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorTypes",
                keyColumn: "ActorTypeId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Actors");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1,
                columns: new[] { "FirstName", "InsertedDate", "LastName" },
                values: new object[] { "Allu", new DateTime(2020, 8, 15, 23, 2, 50, 612, DateTimeKind.Local).AddTicks(9163), "Arjun" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2,
                columns: new[] { "FirstName", "InsertedDate", "LastName" },
                values: new object[] { "Ravi", new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(2571), "Teja" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3,
                columns: new[] { "FirstName", "InsertedDate", "LastName" },
                values: new object[] { "Shree", new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(2630), "Ram" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4,
                columns: new[] { "FirstName", "InsertedDate", "LastName" },
                values: new object[] { "Jnr", new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(2638), "Ntr" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "ActorTypeId", "FirstName", "InsertedDate", "LastName" },
                values: new object[,]
                {
                    { 5, 1, "Mahesh", new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(2642), "Babu" },
                    { 6, 1, "Kamal", new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(2646), "Hasan" }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Released",
                value: new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(5791));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Actors", "Awards", "Director", "Genre", "InsertedDate", "Language", "Plot", "Poster", "Released", "Title", "Year", "imdbId", "imdbrating" },
                values: new object[] { 2, null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2020, 8, 15, 23, 2, 50, 617, DateTimeKind.Local).AddTicks(7074), "Don", null, 0, 5 });
        }
    }
}

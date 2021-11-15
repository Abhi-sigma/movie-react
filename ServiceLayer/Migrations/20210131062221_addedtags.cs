using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceLayer.Migrations
{
    public partial class addedtags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorTypes",
                keyColumn: "ActorTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActorTypes",
                keyColumn: "ActorTypeId",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "MovieDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagsName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_TagId",
                table: "MovieDetails",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDetails_Tags_TagId",
                table: "MovieDetails",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieDetails_Tags_TagId",
                table: "MovieDetails");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_MovieDetails_TagId",
                table: "MovieDetails");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "MovieDetails");

            migrationBuilder.InsertData(
                table: "ActorTypes",
                columns: new[] { "ActorTypeId", "Name" },
                values: new object[] { 1, "Actor" });

            migrationBuilder.InsertData(
                table: "ActorTypes",
                columns: new[] { "ActorTypeId", "Name" },
                values: new object[] { 2, "Actress" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Actors", "AlternateName", "Awards", "Director", "Genre", "InsertedDate", "Language", "Plot", "Poster", "Released", "Title", "Year", "YouTubeLink", "imdbId", "imdbrating" },
                values: new object[] { 1, null, null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "2006/12/18", "Kalyanam", null, null, 0, 4 });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "ActorTypeId", "ImageLink", "InsertedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2021, 1, 26, 18, 45, 48, 663, DateTimeKind.Local).AddTicks(7551), "Allu Arjun" },
                    { 2, 1, null, new DateTime(2021, 1, 26, 18, 45, 48, 668, DateTimeKind.Local).AddTicks(4752), "Ravi Teja" },
                    { 3, 1, null, new DateTime(2021, 1, 26, 18, 45, 48, 668, DateTimeKind.Local).AddTicks(4814), "Shree Ram" },
                    { 4, 1, null, new DateTime(2021, 1, 26, 18, 45, 48, 668, DateTimeKind.Local).AddTicks(4821), "Jnr Ntr" }
                });
        }
    }
}

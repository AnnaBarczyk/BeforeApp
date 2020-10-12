using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BeforeApp.Migrations
{
    public partial class AddStartingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Adress", "City", "Name" },
                values: new object[,]
                {
                    { 1, "Ul. Jeden", "Warszawa", "Plener" },
                    { 2, "Off", "Lodz", "Dom" }
                });

            migrationBuilder.InsertData(
                table: "MusicGenres",
                columns: new[] { "Id", "Name", "PersonId" },
                values: new object[,]
                {
                    { 1, "Techno", null },
                    { 2, "House", null },
                    { 3, "Folk", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventDate", "LocationId", "Moniker", "Name", "PublisherId" },
                values: new object[] { 1, new DateTime(2020, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "tekk2020waw", "Tekk", null });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventDate", "LocationId", "Moniker", "Name", "PublisherId" },
                values: new object[] { 2, new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Orga202ldz", "Organic", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MusicGenres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MusicGenres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MusicGenres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

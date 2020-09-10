using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeforeApp.Migrations
{
    public partial class ConnectorTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicGenres_Person_PersonId",
                table: "MusicGenres");

            migrationBuilder.DropIndex(
                name: "IX_MusicGenres_PersonId",
                table: "MusicGenres");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "MusicGenres");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Events",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PersonMusicGenres",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    MusicGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonMusicGenres", x => new { x.PersonId, x.MusicGenreId });
                    table.ForeignKey(
                        name: "FK_PersonMusicGenres_MusicGenres_MusicGenreId",
                        column: x => x.MusicGenreId,
                        principalTable: "MusicGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonMusicGenres_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventMusicGenres",
                columns: new[] { "EventId", "MusicGenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Birthdate", "Description", "Discriminator", "Email", "Nickname", "Orientation", "Password", "PhotoId", "Sex" },
                values: new object[] { 3, new DateTime(1994, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "<3", "Admin", "admin@elo.pl", "Admin", "Bi", null, null, "Female" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Birthdate", "Description", "Discriminator", "Email", "Nickname", "Orientation", "Password", "PhotoId", "Sex", "User_EventId", "PersonId" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siema elo 520", "User", "technochlopak@elo.pl", "Ziomek", "Straight", null, null, "Male", null, null },
                    { 2, new DateTime(1994, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "<3", "User", "technolaska@elo.pl", "Ziomalka", "Bi", null, null, "Female", null, null }
                });

            migrationBuilder.InsertData(
                table: "PersonMusicGenres",
                columns: new[] { "PersonId", "MusicGenreId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "PersonMusicGenres",
                columns: new[] { "PersonId", "MusicGenreId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "PersonMusicGenres",
                columns: new[] { "PersonId", "MusicGenreId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PersonMusicGenres_MusicGenreId",
                table: "PersonMusicGenres",
                column: "MusicGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "PersonMusicGenres");

            migrationBuilder.DeleteData(
                table: "EventMusicGenres",
                keyColumns: new[] { "EventId", "MusicGenreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EventMusicGenres",
                keyColumns: new[] { "EventId", "MusicGenreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EventMusicGenres",
                keyColumns: new[] { "EventId", "MusicGenreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "MusicGenres",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_MusicGenres_PersonId",
                table: "MusicGenres",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicGenres_Person_PersonId",
                table: "MusicGenres",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

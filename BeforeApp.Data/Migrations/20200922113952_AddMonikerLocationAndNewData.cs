namespace BeforeApp.Migrations
{
    public partial class AddMonikerLocationAndNewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Moniker",
                table: "Locations",
                nullable: true);


            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Adress", "City", "Name" },
                values: new object[] { "Unknown", "Unknown", "Unknown Location" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Adress", "City", "Moniker", "Name" },
                values: new object[] { 3, "Ul. Jeden", "Warszawa", null, "Plener" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonMusicGenres",
                keyColumns: new[] { "PersonId", "MusicGenreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PersonMusicGenres",
                keyColumns: new[] { "PersonId", "MusicGenreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PersonMusicGenres",
                keyColumns: new[] { "PersonId", "MusicGenreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DropColumn(
                name: "Moniker",
                table: "Locations");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Adress", "City", "Name" },
                values: new object[] { "Ul. Jeden", "Warszawa", "Plener" });
        }
    }
}

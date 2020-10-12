namespace BeforeApp.Migrations
{
    public partial class TestMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Person_PublisherId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicGenres_Person_PersonId",
                table: "MusicGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Events_EventId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_UserId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Events_User_EventId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_PersonId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_Person_PersonId",
                table: "Persons",
                newName: "IX_Persons_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_User_EventId",
                table: "Persons",
                newName: "IX_Persons_User_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_UserId",
                table: "Persons",
                newName: "IX_Persons_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_EventId",
                table: "Persons",
                newName: "IX_Persons_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Persons_PublisherId",
                table: "Events",
                column: "PublisherId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicGenres_Persons_PersonId",
                table: "MusicGenres",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Events_EventId",
                table: "Persons",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_UserId",
                table: "Persons",
                column: "UserId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Events_User_EventId",
                table: "Persons",
                column: "User_EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_PersonId",
                table: "Persons",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Persons_PublisherId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicGenres_Persons_PersonId",
                table: "MusicGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Events_EventId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_UserId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Events_User_EventId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_PersonId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_PersonId",
                table: "Person",
                newName: "IX_Person_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_User_EventId",
                table: "Person",
                newName: "IX_Person_User_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_UserId",
                table: "Person",
                newName: "IX_Person_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_EventId",
                table: "Person",
                newName: "IX_Person_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Person_PublisherId",
                table: "Events",
                column: "PublisherId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicGenres_Person_PersonId",
                table: "MusicGenres",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Events_EventId",
                table: "Person",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_UserId",
                table: "Person",
                column: "UserId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Events_User_EventId",
                table: "Person",
                column: "User_EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_PersonId",
                table: "Person",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

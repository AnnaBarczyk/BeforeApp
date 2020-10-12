using Microsoft.EntityFrameworkCore.Migrations;

namespace BeforeApp.Migrations
{
    public partial class TestCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Events_EventId1",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_User_PersonId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_EventId1",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_User_PersonId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "User_PersonId",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_EventId",
                table: "Person",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Moniker",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserId",
                table: "Person",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_User_EventId",
                table: "Person",
                column: "User_EventId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_UserId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Events_User_EventId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_UserId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_User_EventId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "User_EventId",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "EventId1",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_PersonId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Moniker",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Person_EventId1",
                table: "Person",
                column: "EventId1");

            migrationBuilder.CreateIndex(
                name: "IX_Person_User_PersonId",
                table: "Person",
                column: "User_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Events_EventId1",
                table: "Person",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_User_PersonId",
                table: "Person",
                column: "User_PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

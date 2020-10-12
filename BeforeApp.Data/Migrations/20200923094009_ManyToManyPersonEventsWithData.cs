using Microsoft.EntityFrameworkCore.Migrations;

namespace BeforeApp.Migrations
{
    public partial class ManyToManyPersonEventsWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Events_User_EventId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_User_EventId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "User_EventId",
                table: "Person");

            migrationBuilder.CreateTable(
                name: "PersonEvents",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEvents", x => new { x.EventId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonEvents_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PersonEvents",
                columns: new[] { "EventId", "PersonId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "PersonEvents",
                columns: new[] { "EventId", "PersonId" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_PersonEvents_PersonId",
                table: "PersonEvents",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonEvents");

            migrationBuilder.AddColumn<int>(
                name: "User_EventId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_User_EventId",
                table: "Person",
                column: "User_EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Events_User_EventId",
                table: "Person",
                column: "User_EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace makersmatch_server.Migrations
{
    /// <inheritdoc />
    public partial class removesimpleuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_SimpleUser_SenderId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_SimpleUser_User1Id",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_SimpleUser_User2Id",
                table: "Chats");

            migrationBuilder.DropTable(
                name: "SimpleUser");

            migrationBuilder.DropIndex(
                name: "IX_Chats_User1Id",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_User2Id",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "User2Id",
                table: "Chats",
                newName: "User2ID");

            migrationBuilder.RenameColumn(
                name: "User1Id",
                table: "Chats",
                newName: "User1ID");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "ChatMessages",
                newName: "SenderID");

            migrationBuilder.AlterColumn<string>(
                name: "User2ID",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "User1ID",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderID",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User2ID",
                table: "Chats",
                newName: "User2Id");

            migrationBuilder.RenameColumn(
                name: "User1ID",
                table: "Chats",
                newName: "User1Id");

            migrationBuilder.RenameColumn(
                name: "SenderID",
                table: "ChatMessages",
                newName: "SenderId");

            migrationBuilder.AlterColumn<string>(
                name: "User2Id",
                table: "Chats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "User1Id",
                table: "Chats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "ChatMessages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SimpleUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User1Id",
                table: "Chats",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User2Id",
                table: "Chats",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_SimpleUser_SenderId",
                table: "ChatMessages",
                column: "SenderId",
                principalTable: "SimpleUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_SimpleUser_User1Id",
                table: "Chats",
                column: "User1Id",
                principalTable: "SimpleUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_SimpleUser_User2Id",
                table: "Chats",
                column: "User2Id",
                principalTable: "SimpleUser",
                principalColumn: "Id");
        }
    }
}

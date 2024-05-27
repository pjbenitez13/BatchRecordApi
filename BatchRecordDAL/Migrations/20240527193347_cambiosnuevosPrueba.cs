using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatchRecordDAL.Migrations
{
    /// <inheritdoc />
    public partial class cambiosnuevosPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "farmazona");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "test",
                newName: "Users",
                newSchema: "farmazona");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "test",
                newName: "Roles",
                newSchema: "farmazona");

            migrationBuilder.RenameTable(
                name: "AccessResources",
                schema: "test",
                newName: "AccessResources",
                newSchema: "farmazona");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "farmazona",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "farmazona",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "farmazona",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                schema: "farmazona",
                table: "Roles",
                column: "RoleName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                schema: "farmazona",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleName",
                schema: "farmazona",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "farmazona",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "farmazona",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "test");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "farmazona",
                newName: "Users",
                newSchema: "test");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "farmazona",
                newName: "Roles",
                newSchema: "test");

            migrationBuilder.RenameTable(
                name: "AccessResources",
                schema: "farmazona",
                newName: "AccessResources",
                newSchema: "test");
        }
    }
}

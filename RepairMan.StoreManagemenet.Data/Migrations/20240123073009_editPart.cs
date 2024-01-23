using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairMan.StoreManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class editPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Parts",
                newName: "Model");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Parts",
                newName: "Title");
        }
    }
}

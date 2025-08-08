using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D_Persistence_Layer.Migrations
{
    /// <inheritdoc />
    public partial class add_ImageUrl_field_for_productImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductImages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductImages");
        }
    }
}

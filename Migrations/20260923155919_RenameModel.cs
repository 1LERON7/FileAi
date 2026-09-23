using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileAi.Migrations
{
    /// <inheritdoc />
    public partial class RenameModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DownloadAt",
                table: "Files",
                newName: "UploadedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "Files",
                newName: "DownloadAt");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace River.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ignored_directory",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    inactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ignored_directory", x => x.id);
                },
                comment: "Represents an ignorable directory. All children files are considered ignorable.");

            migrationBuilder.CreateTable(
                name: "ignored_file",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    extension = table.Column<string>(type: "text", nullable: false),
                    inactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ignored_file", x => x.id);
                },
                comment: "Represents an ignorable file.");

            migrationBuilder.CreateTable(
                name: "tracked_directory",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    inactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracked_directory", x => x.id);
                },
                comment: "Represents a trackable directory. Changes to the directory, or any of its children files, are also trackable.");

            migrationBuilder.CreateTable(
                name: "tracked_solo_file",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    extension = table.Column<string>(type: "text", nullable: false),
                    inactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracked_solo_file", x => x.id);
                },
                comment: "Represents a trackable file with no parent directory reference.");

            migrationBuilder.CreateTable(
                name: "tracked_file",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    extension = table.Column<string>(type: "text", nullable: false),
                    directory_id = table.Column<long>(type: "bigint", nullable: false),
                    inactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracked_file", x => x.id);
                    table.ForeignKey(
                        name: "FK_tracked_file_tracked_directory_directory_id",
                        column: x => x.directory_id,
                        principalTable: "tracked_directory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents a trackable file with a parent directory reference. Changes to the parent are also trackable.");

            migrationBuilder.CreateIndex(
                name: "IX_tracked_file_directory_id",
                table: "tracked_file",
                column: "directory_id");

            migrationBuilder.CreateIndex(
                name: "IX_tracked_directory_path",
                table: "tracked_directory",
                column: "path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tracked_file_path",
                table: "tracked_file",
                column: "path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ignored_directory_path",
                table: "ignored_directory",
                column: "path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ignored_file_path",
                table: "ignored_file",
                column: "path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tracked_solo_file_path",
                table: "tracked_solo_file",
                column: "path",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tracked_file");

            migrationBuilder.DropTable(
                name: "ignored_directory");

            migrationBuilder.DropTable(
                name: "ignored_file");

            migrationBuilder.DropTable(
                name: "tracked_solo_file");

            migrationBuilder.DropTable(
                name: "tracked_directory");
        }
    }
}

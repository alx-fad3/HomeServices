using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeServices.Migrations
{
    public partial class _init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectoryModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    Size = table.Column<double>(nullable: false),
                    Exists = table.Column<bool>(nullable: false),
                    DirectoryId = table.Column<int>(nullable: true),
                    DirectoryModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileModels_DirectoryModels_DirectoryModelId",
                        column: x => x.DirectoryModelId,
                        principalTable: "DirectoryModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DirectoryModels",
                columns: new[] { "Id", "Name", "Path" },
                values: new object[] { 1, "Init", null });

            migrationBuilder.InsertData(
                table: "FileModels",
                columns: new[] { "Id", "DirectoryId", "DirectoryModelId", "Exists", "Extension", "Name", "Size" },
                values: new object[] { 1, null, null, false, null, "Init", 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_FileModels_DirectoryModelId",
                table: "FileModels",
                column: "DirectoryModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileModels");

            migrationBuilder.DropTable(
                name: "DirectoryModels");
        }
    }
}

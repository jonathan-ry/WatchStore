using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Watches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ItemNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    FullDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Caliber = table.Column<string>(type: "TEXT", nullable: true),
                    Movement = table.Column<string>(type: "TEXT", nullable: true),
                    Chronograph = table.Column<string>(type: "TEXT", nullable: true),
                    Jewel = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Diameter = table.Column<float>(type: "REAL", nullable: false),
                    Thickness = table.Column<float>(type: "REAL", nullable: false),
                    Height = table.Column<float>(type: "REAL", nullable: false),
                    CaseMaterial = table.Column<string>(type: "TEXT", nullable: true),
                    StrapMaterial = table.Column<string>(type: "TEXT", nullable: true),
                    PhotoUri = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watches", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Watches");
        }
    }
}

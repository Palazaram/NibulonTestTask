using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NibulonTestTask.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KRAJs",
                columns: table => new
                {
                    KRAJ_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NRAJ = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KRAJs", x => x.KRAJ_ID);
                });

            migrationBuilder.CreateTable(
                name: "OBLs",
                columns: table => new
                {
                    KOBL = table.Column<int>(type: "int", nullable: false),
                    NOBL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OBLs", x => x.KOBL);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CITY_KOD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KRAJ_KOD = table.Column<int>(type: "int", nullable: true),
                    OBL_KOD = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CITY_KOD);
                    table.ForeignKey(
                        name: "FK_Cities_KRAJs_KRAJ_KOD",
                        column: x => x.KRAJ_KOD,
                        principalTable: "KRAJs",
                        principalColumn: "KRAJ_ID");
                    table.ForeignKey(
                        name: "FK_Cities_OBLs_OBL_KOD",
                        column: x => x.OBL_KOD,
                        principalTable: "OBLs",
                        principalColumn: "KOBL");
                });

            migrationBuilder.CreateTable(
                name: "AUPs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INDEX_A = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CITY_KOD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OBL_KOD = table.Column<int>(type: "int", nullable: true),
                    RAJ_KOD = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUPs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AUPs_Cities_CITY_KOD",
                        column: x => x.CITY_KOD,
                        principalTable: "Cities",
                        principalColumn: "CITY_KOD");
                    table.ForeignKey(
                        name: "FK_AUPs_KRAJs_RAJ_KOD",
                        column: x => x.RAJ_KOD,
                        principalTable: "KRAJs",
                        principalColumn: "KRAJ_ID");
                    table.ForeignKey(
                        name: "FK_AUPs_OBLs_OBL_KOD",
                        column: x => x.OBL_KOD,
                        principalTable: "OBLs",
                        principalColumn: "KOBL");
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CITY_KOD", "CITY", "KRAJ_KOD", "OBL_KOD" },
                values: new object[,]
                {
                    { "00002", "с. Першотравневе", null, null },
                    { "00004", "с. Білозірка", null, null },
                    { "00005", "с. Матроска", null, null },
                    { "00007", "с. Проказине", null, null }
                });

            migrationBuilder.InsertData(
                table: "KRAJs",
                columns: new[] { "KRAJ_ID", "NRAJ" },
                values: new object[,]
                {
                    { 1, "Фастівський" },
                    { 2, "Білоцерківський" },
                    { 3, "Полтавський" },
                    { 4, "Уманський" },
                    { 5, "Кам'янець-Подільський" },
                    { 6, "Драбівський" },
                    { 7, "Дерагчівський" },
                    { 8, "Валківський" },
                    { 9, "Кагарлицький" }
                });

            migrationBuilder.InsertData(
                table: "OBLs",
                columns: new[] { "KOBL", "NOBL" },
                values: new object[,]
                {
                    { 1101, "Київська" },
                    { 1103, "Чернігівська" },
                    { 1104, "Сумська" },
                    { 1105, "Черкаська" },
                    { 1107, "Полтавська" },
                    { 1108, "Миколаївська" },
                    { 1110, "Кіровоградська" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CITY_KOD", "CITY", "KRAJ_KOD", "OBL_KOD" },
                values: new object[,]
                {
                    { "00001", "с. Кислівка", 2, 1101 },
                    { "00003", "с. Ягідне", null, 1103 },
                    { "00006", "с. Кучерівка", null, 1104 },
                    { "00008", "с. Івахни", 4, 1105 },
                    { "00009", "с. Горобіївка", 1, 1101 },
                    { "00010", "с. Паляничинці", 2, null },
                    { "00011", "м. Полтава", 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUPs_CITY_KOD",
                table: "AUPs",
                column: "CITY_KOD");

            migrationBuilder.CreateIndex(
                name: "IX_AUPs_OBL_KOD",
                table: "AUPs",
                column: "OBL_KOD");

            migrationBuilder.CreateIndex(
                name: "IX_AUPs_RAJ_KOD",
                table: "AUPs",
                column: "RAJ_KOD");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_KRAJ_KOD",
                table: "Cities",
                column: "KRAJ_KOD");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_OBL_KOD",
                table: "Cities",
                column: "OBL_KOD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUPs");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "KRAJs");

            migrationBuilder.DropTable(
                name: "OBLs");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_Crud_User_API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Salt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreSalt = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    PostSalt = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Salt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: "admin"),
                    LastName = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: "admin"),
                    Email = table.Column<string>(type: "NVARCHAR(100)", nullable: false, defaultValue: "admin@admin.be"),
                    Pwd = table.Column<byte[]>(type: "VARBINARY(64)", nullable: false),
                    Street = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    HouseNumber = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    ZipCode = table.Column<int>(type: "INT", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Role = table.Column<int>(type: "INT", nullable: false, defaultValue: 1),
                    IsActif = table.Column<int>(type: "INT", nullable: false, defaultValue: 1),
                    SaltId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_User_T_Salt_SaltId",
                        column: x => x.SaltId,
                        principalTable: "T_Salt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_User_Email",
                table: "T_User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_User_SaltId",
                table: "T_User",
                column: "SaltId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_User");

            migrationBuilder.DropTable(
                name: "T_Salt");
        }
    }
}

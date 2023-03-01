using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFTure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActivityType_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.RenameColumn(
                name: "ActivityTypeId",
                table: "UserActivities", 
                newName: "ActivityType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                });

            migrationBuilder.RenameColumn(
                name: "ActivityType",
                table: "UserActivities",
                newName: "ActivityTypeId");
        }
    }
}

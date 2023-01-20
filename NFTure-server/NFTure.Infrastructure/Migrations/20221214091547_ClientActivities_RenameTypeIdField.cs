using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFTure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClientActivitiesRenameTypeIdField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivityType",
                table: "ClientActivities",
                newName: "ActivityTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivityTypeId",
                table: "ClientActivities",
                newName: "ActivityType");
        }
    }
}

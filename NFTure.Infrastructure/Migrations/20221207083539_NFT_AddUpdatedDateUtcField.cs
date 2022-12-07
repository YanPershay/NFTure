using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFTure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NFTAddUpdatedDateUtcField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastUpdatedDateUtc",
                table: "Nfts",
                type: "datetimeoffset",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedDateUtc",
                table: "Nfts");
        }
    }
}

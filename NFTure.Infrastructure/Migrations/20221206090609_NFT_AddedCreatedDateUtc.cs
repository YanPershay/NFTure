using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFTure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NFTAddedCreatedDateUtc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDateUtc",
                table: "Nfts",
                type: "datetimeoffset",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                table: "Nfts");
        }
    }
}

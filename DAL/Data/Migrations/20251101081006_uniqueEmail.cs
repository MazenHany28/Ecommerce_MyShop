using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class uniqueEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // 1. Drop the existing non-unique index (if it exists)
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "Users");

            // 2. Create the new UNIQUE index
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail",
                unique: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            // 1. Drop the unique index
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "Users");

            // 2. Re-create the non-unique index (reverts to original state)
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail",
                unique: false); // Explicitly specify non-unique

        }
    }
}

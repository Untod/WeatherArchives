using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask_DynamicSun.Migrations
{
    /// <inheritdoc />
    public partial class U1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "RelativeHumidity",
                table: "WeatherDetails",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDetails_Date",
                table: "WeatherDetails",
                column: "Date",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeatherDetails_Date",
                table: "WeatherDetails");

            migrationBuilder.AlterColumn<int>(
                name: "RelativeHumidity",
                table: "WeatherDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}

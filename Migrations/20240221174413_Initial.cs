using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask_DynamicSun.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: true),
                    RelativeHumidity = table.Column<int>(type: "int", nullable: true),
                    DewPoint = table.Column<float>(type: "real", nullable: true),
                    AtmosphericPressure = table.Column<int>(type: "int", nullable: true),
                    WindDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindSpeed = table.Column<int>(type: "int", nullable: true),
                    Cloudiness = table.Column<int>(type: "int", nullable: true),
                    CloudBase = table.Column<int>(type: "int", nullable: true),
                    HorizontalVisibility = table.Column<int>(type: "int", nullable: true),
                    Conditions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherDetails");
        }
    }
}

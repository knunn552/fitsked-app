using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitskedApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWorkoutTypeFromUserWorkoutEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutType",
                table: "UserWorkouts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkoutType",
                table: "UserWorkouts",
                type: "int",
                nullable: true);
        }
    }
}

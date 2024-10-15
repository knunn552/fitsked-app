using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitskedApp.Migrations
{
    /// <inheritdoc />
    public partial class RemovedWorkoutTypeFromUserExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutType",
                table: "UserExercises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkoutType",
                table: "UserExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

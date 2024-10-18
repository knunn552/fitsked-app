using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitskedApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingRespectiveEnumsToModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutType",
                table: "UserWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "UserExercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutType",
                table: "UserExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises");

            migrationBuilder.DropColumn(
                name: "WorkoutType",
                table: "UserWorkouts");

            migrationBuilder.DropColumn(
                name: "WorkoutType",
                table: "UserExercises");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "UserExercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}

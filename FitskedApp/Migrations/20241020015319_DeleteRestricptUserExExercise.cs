using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitskedApp.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRestricptUserExExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

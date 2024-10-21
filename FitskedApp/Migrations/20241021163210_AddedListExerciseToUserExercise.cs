using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitskedApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedListExerciseToUserExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserExerciseId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserExerciseId",
                table: "Exercises",
                column: "UserExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_UserExercises_UserExerciseId",
                table: "Exercises",
                column: "UserExerciseId",
                principalTable: "UserExercises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_UserExercises_UserExerciseId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_UserExerciseId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "UserExerciseId",
                table: "Exercises");
        }
    }
}

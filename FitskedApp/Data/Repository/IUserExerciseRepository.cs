using FitskedApp.DTO;
using FitskedApp.Models;

namespace FitskedApp.Data.Repository
{
    public interface IUserExerciseRepository
    {
        Task<List<ExerciseDTO>> GetExercisesBasedOnWorkoutType(WorkoutType workoutType);
        List<ExerciseDTO> GetExercisesFromWorkoutListBasedOnExerciseType(List<ExerciseDTO> exercises, ExerciseType exerciseType);
        Task AddUserExercise(UserExercise userExercise);
        Task PersistUpdatedListOfUserWorkoutsToDatabaseAsync(List<UserWorkout> userWorkouts, List<int> updatedWorkoutIds);
        Task UpdateExercise(UserExercise userExercise);
    }
}

using FitskedApp.DTO;
using FitskedApp.Models;

namespace FitskedApp.Data.Repository
{
    public interface IUserExerciseRepository
    {
        List<ExerciseDTO> GetExercisesFromWorkoutListBasedOnExerciseType(List<ExerciseDTO> exercises, ExerciseType exerciseType);
        Task AddUserExercise(UserExercise userExercise);
        Task PersistUpdatedListOfUserWorkoutsToDatabaseAsync(List<UserWorkout> userWorkouts, List<int> updatedExerciseIds, List<int> deletedExerciseIds);
        Task UpdateExercise(UserExercise userExercise);
        Task DeleteExercise(int id);
        Task DeleteListOfExercises(List<int> ids); 

    }
}

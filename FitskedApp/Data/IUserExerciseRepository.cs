using FitskedApp.DTO;
using FitskedApp.Models;

namespace FitskedApp.Data
{
    public interface IUserExerciseRepository
    {
        Task<List<ExerciseDTO>> GetExercisesBasedOnWorkoutType(WorkoutType workoutType);
        List<ExerciseDTO> GetExercisesFromWorkoutListBasedOnExerciseType(List<ExerciseDTO> exercises, ExerciseType exerciseType);
        Task AddUserExercise(UserExercise userExercise);
    }
}

using FitskedApp.Models;

namespace FitskedApp.Data
{
    public interface IUserExerciseRepository
    {


        Task<List<Exercise>> GetExercisesBasedOnWorkoutType(WorkoutType workoutType);
        List<Exercise> GetExercisesFromWorkoutListBasedOnExerciseType(List<Exercise> exercises, ExerciseType exerciseType);
    }
}

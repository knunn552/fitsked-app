using FitskedApp.DTO;
using FitskedApp.Models;

namespace FitskedApp.Data.Service
{
    public interface IExerciseService
    {
        public Task<List<ExerciseDTO>> GetExerciseListAsync(WorkoutType workoutType);
        public Task<List<ExerciseDTO>> GetFullExerciseListAsync();
    }
}

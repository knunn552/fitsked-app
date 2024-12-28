using FitskedApp.DTO;
using FitskedApp.Models;

namespace FitskedApp.Data.Service
{
    public interface IExerciseService
    {
        public List<ExerciseDTO> GetExerciseListBasedOnWorkoutType(WorkoutType workoutType, List<ExerciseDTO> exerciseDTOs);
        public Task<List<ExerciseDTO>> GetFullExerciseListAsync();
    }
}

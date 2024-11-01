using FitskedApp.DTO;

namespace FitskedApp.Data.Service
{
    public interface IExerciseService
    {
        public Task<List<ExerciseDTO>> GetExerciseListAsync();
    }
}

using FitskedApp.Models;
using Microsoft.EntityFrameworkCore;
using FitskedApp.DTO;

namespace FitskedApp.Data
{
    public class UserExerciseRepository : IUserExerciseRepository
    {   
        private ApplicationDbContext? _context;

        public UserExerciseRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task AddUserExercise(UserExercise userExercise)
        {
            _context.Add(userExercise);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ExerciseDTO>> GetExercisesBasedOnWorkoutType(WorkoutType workoutType)
        {
            return await _context.Exercises.Where(e => e.WorkoutType == workoutType).
                Select(e => new ExerciseDTO
                {
                    ExerciseId = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    WorkoutType = e.WorkoutType,
                    ExerciseType = e.ExerciseType
                }).ToListAsync();
        }

        public List<ExerciseDTO> GetExercisesFromWorkoutListBasedOnExerciseType(List<ExerciseDTO> exercises, ExerciseType exerciseType)
        {
            return exercises.Where(e => e.ExerciseType == exerciseType).ToList();
        }
    }
}

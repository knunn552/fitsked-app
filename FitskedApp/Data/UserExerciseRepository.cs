using FitskedApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitskedApp.Data
{
    public class UserExerciseRepository : IUserExerciseRepository
    {   
        private ApplicationDbContext? _context;

        public UserExerciseRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Exercise>> GetExercisesBasedOnWorkoutType(WorkoutType workoutType)
        {
            // First, I want to get the list of exercises based on WorkoutType
            // Then I'll make a method the takes this methods returned list and filters based on ExerciseType, from which point we'll display the relevant exercises
            return await _context.Exercises.Where(e => e.WorkoutType == workoutType).ToListAsync();
        }

        public List<Exercise> GetExercisesFromWorkoutListBasedOnExerciseType(List<Exercise> exercises, ExerciseType exerciseType)
        {
            return exercises.Where(e => e.ExerciseType == exerciseType).ToList();
        }
    }
}

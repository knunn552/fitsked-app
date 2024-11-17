using FitskedApp.Models;
using Microsoft.EntityFrameworkCore;
using FitskedApp.DTO;
using FitskedApp.Components.Account.Pages;

namespace FitskedApp.Data.Repository
{
    public class UserExerciseRepository : IUserExerciseRepository
    {
        private ApplicationDbContext? _context;

        public UserExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task PersistUpdatedListOfUserWorkoutsToDatabaseAsync(List<UserWorkout> userWorkouts, List<int> updatedExerciseIds, List<int> deletedExerciseIds)
        {
            foreach (var userWorkout in userWorkouts)
            {
                foreach (var userExercise in userWorkout.UserExercises)
                {
                    if (updatedExerciseIds.Contains(userExercise.Id))
                    {
                        await UpdateExercise(userExercise);
                    }
                    // Need an if statement here if deletedExerciseId's exist then we will delete that particular exercise
                    // Else, we will most likely add a user exercise based on the particular workoutid
                    
                }
            }
        }

        public async Task UpdateExercise(UserExercise userExercise)
        {
            if (_context.Entry(userExercise).State != EntityState.Unchanged)
            {
                _context.Update(userExercise);
                await _context.SaveChangesAsync();
            }
        }
    }
}

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

        public async Task DeleteExercise(int id)
        {
            if(id != 0)
            {
                var userExercise = _context.UserExercises.FindAsync(id);
                if (userExercise != null)
                {
                    _context.Remove(userExercise);
                    await _context.SaveChangesAsync();
                }
            }
            
        }

        public async Task DeleteListOfExercises(List<int> ids)
        {
            // Important to note that RemoveRange expects a list of entities, not just ids
            var exercisesToDelete = await _context.UserExercises.
                Where(exercise => ids.Contains(exercise.Id))
                .ToListAsync();

            _context.RemoveRange(exercisesToDelete);
            await _context.SaveChangesAsync(); 
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
                    if ((updatedExerciseIds.Contains(userExercise.Id)) && userExercise.Id != 0)
                    {
                        await UpdateExercise(userExercise);
                    }
                    
                    else if(userExercise.Id == 0) // It's going to be tough to delete an exercise that is no longer in the workout.
                    {
                        userExercise.UserWorkoutId = userWorkout.Id;
                        await AddUserExercise(userExercise);   
                    }   
                }
            }
            
            if (deletedExerciseIds != null)
            {
                await DeleteListOfExercises(deletedExerciseIds);
            }
            // This is where we make the deletion because there's no way we can delete an exercise if its no longer in the workout

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

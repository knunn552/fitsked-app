using FitskedApp.Models;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace FitskedApp.Data.Repository
{
    public class UserWorkoutRepository : IUserWorkoutRepository
    {
        public ApplicationDbContext _context { get; set; }

        public UserWorkoutRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddWorkout(UserWorkout workout)
        {
            _context.Add(workout);
            await _context.SaveChangesAsync(); // Returns 1 if Success
        }

        public async Task UpdateWorkout(UserWorkout workout)
        {
            if (_context.Entry(workout).State != EntityState.Unchanged)
            {
                _context.Update(workout);
                await _context.SaveChangesAsync();
            }
        }

        public async Task PersistListOfUserWorkoutsToDatabaseAsync(List<UserWorkout> userWorkouts, int planId)
        {
            try
            {
                foreach (UserWorkout userworkout in userWorkouts)
                {
                    userworkout.PlanId = planId;
                    await AddWorkout(userworkout);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to persist UserWorkout for Plan {planId}:", ex.Message);
            }
        }

        public async Task<List<UserWorkout>> GetListOfUserWorkoutsByPlanIdAsync(int planId)
        {
            return await _context.UserWorkouts.
                Include(uw => uw.UserExercises).
                Where(uw => uw.PlanId == planId).
                ToListAsync();
        }

        //public async Task PersistUpdatedListOfUserWorkoutsToDatabaseAsync(List<UserWorkout> userWorkouts, int planId)
        //{
        //    try
        //    {
        //        foreach (UserWorkout userworkout in userWorkouts)
        //        {
        //            userworkout.PlanId = planId;
        //            await UpdateWorkout(userworkout);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Unable to persist UserWorkout for Plan {planId}:", ex.Message);
        //    }
        //}

        public async Task PersistUpdatedListOfUserWorkoutsToDatabaseAsync(List<UserWorkout> userWorkouts, int planId)
        {
            try
            {
                // Retrieve existing workouts for the given planId
                var existingWorkouts = await _context.UserWorkouts
                    .Where(uw => uw.PlanId == planId)
                    .ToListAsync();

                foreach (var userWorkout in userWorkouts)
                {
                    userWorkout.PlanId = planId;

                    // Check if the workout already exists in the database
                    var existingWorkout = existingWorkouts.FirstOrDefault(ew => ew.Id == userWorkout.Id);

                    if (existingWorkout != null)
                    {
                        // Update existing workout properties with new values
                        _context.Entry(existingWorkout).CurrentValues.SetValues(userWorkout);
                    }
                    else
                    {
                        // Add new workout if it doesn't exist
                        await _context.UserWorkouts.AddAsync(userWorkout);
                    }
                }

                // Commit all changes in a single save
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to persist UserWorkouts for Plan {planId}: {ex.Message}");
            }
        }

    }
}

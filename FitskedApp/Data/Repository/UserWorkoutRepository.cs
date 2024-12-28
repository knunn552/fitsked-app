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
    }
}

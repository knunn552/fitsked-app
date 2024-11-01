using FitskedApp.Models;

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
    }
}

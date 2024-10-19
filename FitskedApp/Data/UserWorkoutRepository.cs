using FitskedApp.Models;

namespace FitskedApp.Data
{
    public class UserWorkoutRepository : IUserWorkoutRepository
    {
        public ApplicationDbContext _context { get; set; }
        public UserWorkoutRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task AddWorkout(UserWorkout workout) 
        {
            _context.Add(workout);
            await _context.SaveChangesAsync(); // Returns 1 if Success
        }
    }
}

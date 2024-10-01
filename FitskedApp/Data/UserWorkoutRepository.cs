using FitskedApp.Models;

namespace FitskedApp.Data
{
    public class UserWorkoutRepository : IUserWorkoutRepository
    {
        // We are going to just define our methods, they'll be implemented in child classes
        // Need to bring in our context field
        public ApplicationDbContext _context { get; set; }

        // Create our constructor
        public UserWorkoutRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task addNewWorkout(UserWorkout workout) 
        {
            _context.Add(workout);
            await _context.SaveChangesAsync(); // The EF Add method is an in-memory operation. The SaveChanges is the actual IO bound operation
        }

        Task IUserWorkoutRepository.createNewWorkout()
        {
            throw new NotImplementedException();
        }

        Task IUserWorkoutRepository.deleteWorkout()
        {
            throw new NotImplementedException();
        }
    }
}

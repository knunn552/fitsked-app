using FitskedApp.Models;

namespace FitskedApp.Data
{
    public class UserExerciseRepository : IUserExerciseRepository
    {
        // Need to set a variable of type FitskedDbContext to be able to use Entity Framework
        // TODO Take out the above message as that is considered zombie code
        private ApplicationDbContext? _context;

        UserExerciseRepository(ApplicationDbContext? context)
        {
            this._context = context;
        }

        public List<Exercise> GetAllExercises()
        {
            throw new NotImplementedException();
        }

        public List<Exercise> GetExercises()
        {
            return _context.Exercises.ToList();
        }

        public void addNewExercise()
        {
            _context.Exercises.Add(new Exercise());
        }
    }
}

using FitskedApp.Models;

namespace FitskedApp.Data
{
    public interface IUserExerciseRepository
    {
        public List<Exercise> GetAllExercises();
        public void addNewExercise() { }
    }
}

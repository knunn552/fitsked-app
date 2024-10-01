using FitskedApp.Models;

namespace FitskedApp.Data
{
    public interface IUserWorkoutRepository
    {
        public Task addNewWorkout(UserWorkout workout); // This is an asynchronous method because were dealing with a db operations
        public Task createNewWorkout();

        public Task deleteWorkout();
    }
}

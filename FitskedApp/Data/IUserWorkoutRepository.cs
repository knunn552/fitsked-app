using FitskedApp.Models;

namespace FitskedApp.Data
{
    public interface IUserWorkoutRepository
    {
        public Task AddWorkout(UserWorkout workout);
        public Task PersistListOfUserWorkoutsToDatabaseAsync(List<UserWorkout> userWorkouts, int planId);
    }
}

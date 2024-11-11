using FitskedApp.Models;

namespace FitskedApp.Data.Repository
{
    public interface IUserWorkoutRepository
    {
        public Task AddWorkout(UserWorkout workout);
        public Task PersistListOfUserWorkoutsToDatabaseAsync(List<UserWorkout> userWorkouts, int planId);
        public Task<List<UserWorkout>> GetListOfUserWorkoutsByPlanIdAsync(int planId);
    }
}

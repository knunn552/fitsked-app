using FitskedApp.Models;

namespace FitskedApp.Data.Repository
{
    public interface IUserPlanRepository
    {
        public Task<List<Plan>> GetAllPlansByUserId(string userId);
        public Plan GetPlanById(int planId);
        public Task<int> AddPlan(Plan plan);
        public Task<int> UpdatePlanAsync(Plan plan);
        public Task DeletePlanAsync(int planId);
    }
}

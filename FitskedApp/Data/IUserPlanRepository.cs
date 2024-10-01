using FitskedApp.Models;

namespace FitskedApp.Data
{
    public interface IUserPlanRepository
    {
        IEnumerable<Plan> GetPlans();
        Plan GetPlanById(int planId);
        public Task<int> AddPlan(Plan plan);
        void UpdatePlan(Plan plan);
        void DeletePlan(int planId);
    }
}

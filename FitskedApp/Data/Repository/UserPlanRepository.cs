using FitskedApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitskedApp.Data.Repository
{
    public class UserPlanRepository : IUserPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public UserPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Plan> GetPlans()
        {
            return _context.Plans.Include(p => p.UserWorkouts).ToList();
        }

        public Plan GetPlanById(int planId)
        {
            return _context.Plans.Find(planId);
        }

        public async Task<int> AddPlan(Plan plan)
        {
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();

            return plan.Id;
        }
        public void UpdatePlan(Plan plan)
        {
            _context.Plans.Update(plan);
            _context.SaveChanges();
        }
        public void DeletePlan(int planId)
        {
            var plan = _context.Plans.Find(planId);
            if (plan != null)
            {
                _context.Plans.Remove(plan);
                _context.SaveChanges();
            }
        }
    }
}

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

        public async Task<List<Plan>> GetAllPlansByUserId(string userId)
        {

            return await _context.Plans.Where(e => e.ApplicationUserId == userId).ToListAsync();
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

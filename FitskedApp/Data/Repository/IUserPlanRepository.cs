﻿using FitskedApp.Models;

namespace FitskedApp.Data.Repository
{
    public interface IUserPlanRepository
    {
        public Task<List<Plan>> GetAllPlansByUserId(string userId);
        Plan GetPlanById(int planId);
        public Task<int> AddPlan(Plan plan);
        void UpdatePlan(Plan plan);
        void DeletePlan(int planId);
    }
}

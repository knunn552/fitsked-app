using FitskedApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitskedApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Plan> Plans { get; set; }
        public DbSet<UserWorkout> UserWorkouts { get; set; }

        public DbSet<UserExercise> UserExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        // Below we are using Modelbuilder to create our relationships.
        // EF will automatically map our models  together based on naming convention, but using Modelbuilder gives us explicit control
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plan>()
                .HasMany(u => u.UserWorkouts)
                .WithOne(ui => ui.Plan)
                .HasForeignKey(i => i.PlanId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserWorkout>()
                .HasMany(i => i.UserExercises)
                .WithOne(ui => ui.UserWorkout)
                .HasForeignKey(j => j.UserWorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Plans)
                .WithOne(i => i.ApplicationUser)
                .HasForeignKey(o => o.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

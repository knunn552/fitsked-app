using FitskedApp.Data;

namespace FitskedApp.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string ApplicationUserId { get; set; } 
        public ApplicationUser ApplicationUser { get; set; } 
        public ICollection<UserWorkout> UserWorkouts { get; set; } = new List<UserWorkout>(); 
    }
}

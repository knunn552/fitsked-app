namespace FitskedApp.Models
{
    public class UserWorkout
    {
        public int Id { get; set; }
        public int PlanId { get; set; } 
        public WorkoutType? WorkoutType { get; set; }
        public Plan? Plan { get; set; } 
        public ICollection<UserExercise>? UserExercises { get; set; } = new List<UserExercise>(); 
    }
}

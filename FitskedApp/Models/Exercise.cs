namespace FitskedApp.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public WorkoutType WorkoutType { get; set; }
        public ExerciseType ExerciseType { get; set; }
    }
}

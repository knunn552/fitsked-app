using FitskedApp.Models;

namespace FitskedApp.DTO
{
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public WorkoutType WorkoutType { get; set; }
        public ExerciseType ExerciseType { get; set; }

    }
}

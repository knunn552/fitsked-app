using FitskedApp.Data;

namespace FitskedApp.Models
{
    public class Exercise
    {
        private readonly ApplicationDbContext _db;

        public Exercise(ApplicationDbContext db)
        {
            this._db = db;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public WorkoutType WorkoutType { get; set; }
    }
}

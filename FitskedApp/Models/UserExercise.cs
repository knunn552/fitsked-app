﻿using FitskedApp.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitskedApp.Models
{
    public class UserExercise
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public WorkoutType WorkoutType { get; set; }
        public int ExerciseId {  get; set; }
        public ExerciseType ExerciseType { get; set; }
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public int Weight { get; set; }
        public string? VideoUrl { get; set; }
        public int UserWorkoutId { get; set; }
        public UserWorkout? UserWorkout { get; set; }

        [NotMapped]
        public List<ExerciseDTO> FilteredExercises { get; set; } = new();
    }
}

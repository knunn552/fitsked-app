using FitskedApp.DTO;
using FitskedApp.Models;

namespace FitskedApp.Data.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IUserExerciseRepository _userExerciseRepository;
        public UserExercise userExercise = new UserExercise();
        public List<ExerciseDTO> listOfExercisesByWorkoutType = new();

        public ExerciseRepository(IUserExerciseRepository userExerciseRepository)
        {
            _userExerciseRepository = userExerciseRepository;
        }

        public Task FilterListOfWorkoutTypeByExerciseTypeAsync()
        {
            throw new NotImplementedException();
        }
    }
}

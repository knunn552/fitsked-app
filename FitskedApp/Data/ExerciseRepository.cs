
using FitskedApp.DTO;
using FitskedApp.Models;

namespace FitskedApp.Data
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IUserExerciseRepository _userExerciseRepository;
        public UserExercise userExercise = new UserExercise();
        public List<ExerciseDTO> listOfExercisesByWorkoutType = new();

        public ExerciseRepository(IUserExerciseRepository userExerciseRepository)
        {
            this._userExerciseRepository = userExerciseRepository;
        }

        public Task FilterListOfWorkoutTypeByExerciseTypeAsync()
        {
            throw new NotImplementedException();
        }
    }
}

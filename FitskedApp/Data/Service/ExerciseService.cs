using FitskedApp.DTO;
using FitskedApp.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FitskedApp.Data.Service
{
    public class ExerciseService : IExerciseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExerciseService(IHttpClientFactory httpClientFactory) 
        {
            this._httpClientFactory = httpClientFactory;
        }
        public async Task<List<ExerciseDTO>> GetExerciseListAsync(WorkoutType workouttype)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var workoutTypeString = workouttype.ToString();
            try
            {
                var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
                options.Converters.Add(new JsonStringEnumConverter());

                List<ExerciseDTO> exerciseList = await client.GetFromJsonAsync<List<ExerciseDTO>>(
                    $"http://localhost:5279/api/exercises/by-workout-type/{workoutTypeString}", options);

                return exerciseList ?? new List<ExerciseDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<ExerciseDTO>();
        }

    }
}

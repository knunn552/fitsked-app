using FitskedApp.Data.Service;
using FitskedApp.DTO;
using FitskedApp.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

public class ExerciseService : IExerciseService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _exerciseApiBaseUrl;

    public ExerciseService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _exerciseApiBaseUrl = configuration["ApiSettings:ExerciseApiBaseUrl"]
            ?? throw new InvalidOperationException("Exercise API base URL is not configured.");
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
                $"{_exerciseApiBaseUrl}/api/exercises/by-workout-type/{workoutTypeString}", options);

            return exerciseList ?? new List<ExerciseDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<ExerciseDTO>();
    }
}

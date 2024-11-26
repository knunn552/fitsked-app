using FitskedApp.Data.Service;
using FitskedApp.DTO;
using FitskedApp.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

public class ExerciseService : IExerciseService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiBaseUrl;
    private readonly ILogger<ExerciseService> _logger;

    public ExerciseService(IHttpClientFactory httpClientFactory, ILogger<ExerciseService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL")
                      ?? throw new InvalidOperationException("API Base URL is not configured. Set the 'API_BASE_URL' environment variable.");
        _logger = logger;
    }

    public async Task<List<ExerciseDTO>> GetExerciseListAsync(WorkoutType workouttype)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        var workoutTypeString = workouttype.ToString();

        try
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                Converters = { new JsonStringEnumConverter() }
            };

            List<ExerciseDTO> exerciseList = await client.GetFromJsonAsync<List<ExerciseDTO>>(
                $"{_apiBaseUrl}/api/exercises/by-workout-type/{workoutTypeString}", options);

            return exerciseList ?? new List<ExerciseDTO>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching exercises for workout type: {WorkoutType}", workoutTypeString);
            return new List<ExerciseDTO>();
        }
    }
}

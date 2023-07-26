using System.Text.Json.Serialization;
namespace EspacioTrivia;
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class Result
{
    [JsonPropertyName("category")]
    public string category { get; set; }

    [JsonPropertyName("type")]
    public string type { get; set; }

    [JsonPropertyName("difficulty")]
    public string difficulty { get; set; }

    [JsonPropertyName("question")]
    public string question { get; set; }

    [JsonPropertyName("correct_answer")]
    public string correct_answer { get; set; }

    [JsonPropertyName("incorrect_answers")]
    public List<string> incorrect_answers { get; set; }
}

public class Root
{
    [JsonPropertyName("response_code")]
    public int response_code { get; set; }

    [JsonPropertyName("results")]
    public List<Result> results { get; set; }
}

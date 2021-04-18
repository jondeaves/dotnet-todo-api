using Newtonsoft.Json;

public class TodoItemDTO
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("isComplete")]
    public bool IsComplete { get; set; }
}
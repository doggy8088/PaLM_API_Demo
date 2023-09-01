using System.Text.Json.Serialization;

public class EmbeddingsOption
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
}
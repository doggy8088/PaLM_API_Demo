using PaLM_API_Demo.Options;
using PaLM_API_Demo.Results;
using System.Text.Json;

public class PaLMClient
{
    public string ApiKey { get; set; }

    public PaLMClient(string apikey)
    {
        this.ApiKey = apikey;
    }

    public async Task<MessageResult> GenerateMessageAsync(MessageOption msg)
    {
        var payload = JsonSerializer.Serialize(msg);

        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://generativelanguage.googleapis.com/v1beta2/models/chat-bison-001:generateMessage?key={ApiKey}");
        var content = new StringContent(payload);
        request.Content = content;
        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(result);
        }

        return JsonSerializer.Deserialize<MessageResult>(result);
    }

    public async Task<TextResult> GenerateTextAsync(TextOption options)
    {
        var payload = JsonSerializer.Serialize(options);

        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://generativelanguage.googleapis.com/v1beta2/models/text-bison-001:generateText?key={ApiKey}");
        var content = new StringContent(payload);
        request.Content = content;
        var response = await client.SendAsync(request);
        //response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(result);
        }

        return JsonSerializer.Deserialize<TextResult>(result);
    }

    public async Task<EmbeddingResult> GenerateEmbeddingsAsync(EmbeddingsOption options)
    {
        var payload = JsonSerializer.Serialize(options);

        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://generativelanguage.googleapis.com/v1beta2/models/embedding-gecko-001:embedText?key={ApiKey}");
        var content = new StringContent(payload);
        request.Content = content;
        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(result);
        }

        return JsonSerializer.Deserialize<EmbeddingResult>(result);
    }
}

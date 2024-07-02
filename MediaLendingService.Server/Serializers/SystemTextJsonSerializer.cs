using System.Text.Json;
using Microsoft.Extensions.Options;

namespace MediaLendingService.Server.Serializers;

public class SystemTextJsonSerializer(IOptions<JsonSerializerOptions> options) : IJsonSerializer
{
    private readonly JsonSerializerOptions _options = options.Value;

    public string Serialize<T>(T obj) => JsonSerializer.Serialize(obj, _options);

    public T? Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json, _options);
}
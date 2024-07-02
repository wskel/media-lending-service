namespace MediaLendingService.Server.Serializers;

public interface IJsonSerializer
{
    string Serialize<T>(T obj);

    T? Deserialize<T>(string json);
}
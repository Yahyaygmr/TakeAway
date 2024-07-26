using StackExchange.Redis;

namespace TakeAway.Basket.Settings;

public class RedisService
{
    public string _host { get; set; }
    public string _port { get; set; }

    public RedisService(string host, string port)
    {
        _host = host;
        _port = port;
    }

    private ConnectionMultiplexer _connectionMultiplexer;
    public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
    public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
}

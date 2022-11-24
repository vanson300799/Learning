using TestFactory.Interface;

namespace TestFactory.Service
{
    public class RedisConnection : IDatabaseConnection
    {
        public string GetDB()
        {
            return "Redis";
        }
    }
}

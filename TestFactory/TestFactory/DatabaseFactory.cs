using TestFactory.Interface;
using TestFactory.Service;

namespace TestFactory
{
    public static class DatabaseFactory
    {
        public static IDatabaseConnection GetDataBase(string databaseName)
        {
            if(databaseName == "sql")
            {
                return new SqlConnection();
            }
            else if(databaseName == "redis")
            {
                return new RedisConnection();
            }
            else if (databaseName == "test")
            {
                return new TestConnection();
            }
            else
            {
                return new DefaultConnection();
            }
        }
    }
}

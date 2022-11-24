using TestFactory.Interface;

namespace TestFactory.Service
{
    public class SqlConnection : IDatabaseConnection
    {
        public string GetDB()
        {
            return "SQL";
        }
    }
}

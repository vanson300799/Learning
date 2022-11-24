using TestFactory.Interface;

namespace TestFactory.Service
{
    public class DefaultConnection : IDatabaseConnection
    {
        public string GetDB()
        {
            return "default";
        }
    }
}

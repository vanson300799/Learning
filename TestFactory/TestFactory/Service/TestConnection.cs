using TestFactory.Interface;

namespace TestFactory.Service
{
    public class TestConnection : IDatabaseConnection
    {
        public string GetDB()
        {
            return "Test";
        }
    }
}

using TestFactory;
using TestFactory.Interface;
using TestFactory.Service;

var databaseName = "test";
IDatabaseConnection databaseConnection = DatabaseFactory.GetDataBase(databaseName);
Console.WriteLine(databaseConnection.GetDB());


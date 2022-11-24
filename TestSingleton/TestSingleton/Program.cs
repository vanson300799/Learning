
using TestSingleton;
SingletonClass test = SingletonClass.getInstance();
SingletonClass test2 = SingletonClass.getInstance();
if(test == test2)
{
    Console.WriteLine(test.GetName());
}

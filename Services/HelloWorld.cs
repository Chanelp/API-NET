namespace WebApiNet.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public string GetHelloWorld(){
            return "Hola mundoo";
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloWorld();
    }
}
using Di.ConsoleApp.Interfaces;

namespace Di.ConsoleApp.Implementation
{
    public class Greeting : IGreeting
    {

        private readonly ISignService _signService;

        public Greeting(ISignService signService)
        {
            _signService = signService;
        }
        public void SayHello()
        {
            Console.WriteLine("Hello mit Guid: " + _signService.Generate());
        }
    }
}
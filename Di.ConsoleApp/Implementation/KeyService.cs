using Di.ConsoleApp.Interfaces;

namespace Di.ConsoleApp.Implementation
{
    public class KeyService : ISignService
    {
        private readonly string _key;
        public KeyService()
        {
            _key = DateTime.UtcNow.Millisecond.ToString().ToHashSet().Aggregate("", (acc, c) => acc + c);
        }

        public string Generate()
        {
            return _key;
        }
    }
}
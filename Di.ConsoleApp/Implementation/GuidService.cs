using Di.ConsoleApp.Interfaces;

namespace Di.ConsoleApp.Implementation
{
    public class GuidService : ISignService
    {
        private readonly string _guid;
        public GuidService()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public string Generate()
        {
            return _guid;
        }
    }
}
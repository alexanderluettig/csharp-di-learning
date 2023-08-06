using Bogus;

namespace Di.Library;
public class DictionaryPlzRepository : IPlzRepository
{
    private readonly IDictionary<string, string[]> _plzDictionary = new Dictionary<string, string[]>();

    public DictionaryPlzRepository()
    {
        var cityFaker = new Faker<string>().CustomInstantiator(f => f.Address.City());
        var plzFaker = new Faker<string>().CustomInstantiator(f => f.Address.ZipCode());

        for (int i = 0; i < 100; i++)
        {
            _plzDictionary.Add(cityFaker.Generate(), plzFaker.GenerateBetween(5, 10).ToArray());
        }
    }

    public string[] GetPlzFrom(string cityname)
    {
        if (_plzDictionary.TryGetValue(cityname, out var plz))
        {
            return plz;
        }
        else
        {
            return Array.Empty<string>();
        }
    }

    public string[] GetCities()
    {
        return _plzDictionary.Keys.ToArray();
    }
}

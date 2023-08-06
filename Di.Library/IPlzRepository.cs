namespace Di.Library
{
    public interface IPlzRepository
    {
        string[] GetPlzFrom(string cityname);
        string[] GetCities();
    }
}
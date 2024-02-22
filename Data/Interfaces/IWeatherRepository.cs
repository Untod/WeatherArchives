using TestTask_DynamicSun.Models;

namespace TestTask_DynamicSun.Data.Interfaces
{
    public interface IWeatherRepository
    {
        IQueryable<WeatherDetails> GetAll();
        WeatherDetails? GetById(int id);
        void Create(WeatherDetails details);
        void Update(WeatherDetails details);
        void Delete(int id);
    }
}

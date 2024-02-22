using TestTask_DynamicSun.Data.Interfaces;
using TestTask_DynamicSun.Models;

namespace TestTask_DynamicSun.Data
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly TestTaskDbContext _context;

        public WeatherRepository(TestTaskDbContext context)
        {
            _context = context;
        }

        public IQueryable<WeatherDetails> GetAll() => _context.WeatherDetails.AsQueryable();

        public WeatherDetails? GetById(int id) => _context.WeatherDetails.FirstOrDefault(x => x.Id == id);

        public void Create(WeatherDetails details)
        {
            _context.WeatherDetails.Add(details);
            _context.SaveChanges();
        }

        public void Update(WeatherDetails details)
        {
            if (GetById(details.Id) != null)
            {
                _context.WeatherDetails.Update(details);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var existed = GetById(id);
            if (existed != null)
            {
                _context.WeatherDetails.Remove(existed);
                _context.SaveChanges();
            }
        }
    }
}

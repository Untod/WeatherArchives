using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Diagnostics;
using TestTask_DynamicSun.Data.Interfaces;
using TestTask_DynamicSun.Models;

namespace TestTask_DynamicSun.Controllers
{
    public class HomeController : Controller
    {
        private const int ITEMS_PER_PAGE = 10;

        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherRepository _repository;

        public HomeController(ILogger<HomeController> logger, IWeatherRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewArchives(int? page = null, int? year = null, int? month = null)
        {
            ViewData["YearFilter"] = year;
            ViewData["MonthFilter"] = month;
            var weatherDetails = _repository.GetAll();
            if (year.HasValue)
                weatherDetails = weatherDetails.Where(x => x.Date.Year == year.Value);
            if (month.HasValue)
                weatherDetails = weatherDetails.Where(x => x.Date.Month == month.Value);
            return View(await PaginatedList<WeatherDetails>.CreateAsync(weatherDetails.AsNoTracking(), ITEMS_PER_PAGE, page ?? 1));
        }

        public IActionResult UploadArchives()
        {
            return View();
        }

        public IActionResult TryUploadArchives(IEnumerable<IFormFile> archives)
        {
            foreach (var archive in archives)
            {
                using (var stream = archive.OpenReadStream())
                {
                    var book = new XSSFWorkbook(stream);
                    try
                    {
                        var sheet = book.GetSheetAt(0);
                        IRow row;
                        for (var rowIndex = 4; rowIndex <= sheet.LastRowNum; rowIndex++)
                        {
                            try
                            {
                                row = sheet.GetRow(rowIndex);
                                if (!DateTime.TryParseExact($"{row.GetCellString(0)} {row.GetCellString(1)}", "dd.MM.yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
                                    continue;
                                var details = new WeatherDetails()
                                {
                                    Date = dateTime,
                                    Temperature = float.TryParse(row.GetCellString(2), out float temperature) ? temperature : null,
                                    RelativeHumidity = int.TryParse(row.GetCellString(3), out int relativeHumidity) ? relativeHumidity : null,
                                    DewPoint = float.TryParse(row.GetCellString(4), out float dewPoint) ? dewPoint : null,
                                    AtmosphericPressure = int.TryParse(row.GetCellString(5), out int atmosphericPressure) ? atmosphericPressure : null,
                                    WindDirection = row.GetCellString(6),
                                    WindSpeed = int.TryParse(row.GetCellString(7), out int windSpeed) ? windSpeed : null,
                                    Cloudiness = int.TryParse(row.GetCellString(8), out int cloudiness) ? cloudiness : null,
                                    CloudBase = int.TryParse(row.GetCellString(9), out int cloudBase) ? cloudBase : null,
                                    HorizontalVisibility = int.TryParse(row.GetCellString(10), out int horizontalVisibility) ? horizontalVisibility : null,
                                    Conditions = row.GetCellString(11)
                                };
                                _repository.Create(details);
                            }
                            catch (Exception ex)
                            {
                                // do nothing
                            }
                        }
                    }
                    finally { book.Close(); }
                }
            }

            return RedirectToAction("UploadArchives");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask_DynamicSun.Models
{
    public class WeatherDetails
    {
        [DisplayName("Номер")]
        public int Id { get; set; }
        [DisplayName("Дата")]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [DisplayName("Температура")]
        public float? Temperature { get; set; }
        [DisplayName("Относительная влажность")]
        public float? RelativeHumidity { get; set; }
        [DisplayName("Точка росы")]
        public float? DewPoint { get; set; }
        [DisplayName("Атмосферное давление")]
        public int? AtmosphericPressure { get; set; }
        [DisplayName("Направление ветра")]
        public string? WindDirection { get; set; }
        [DisplayName("Скорость ветра")]
        public int? WindSpeed { get; set; }
        [DisplayName("Облачность")]
        public int? Cloudiness { get; set; }
        [DisplayName("Нижняя граница облачности")]
        public int? CloudBase {  get; set; }
        [DisplayName("Горизонтальная видимость")]
        public int? HorizontalVisibility {  get; set; }
        [DisplayName("Погодные явления")]
        public string? Conditions {  get; set; }
    }
}

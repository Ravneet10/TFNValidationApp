using System;

namespace TFNValidationApp
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
    public class ValidationTFN
    {
        public string tfnNumber { get; set; }
        public string validationType { get; set; } = "BasicTfn";
    }
}

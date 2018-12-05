using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class WeatherCalc
    {
        public static WeatherModel CalcWeatherOfDay(List<WeatherModel> weathers)
        {
            WeatherModel weatherModel = new WeatherModel();
            List<decimal> temps = new List<decimal>();
            foreach (WeatherModel weather in weathers)
            {
                decimal decTemp = Decimal.Parse(weather.Temp);
                temps.Add(decTemp);
            }
            List<double> intIconCodes = new List<double>();
            for (int i = 3; i < 8; i++)
            {
                string icon = weathers[i].Icon;
                string withoutLetter = icon.Remove(icon.Length - 1);
                double code = double.Parse(withoutLetter);
                intIconCodes.Add(code);
            }
            weatherModel.TempHigh = Math.Round(temps.Max(), 1).ToString();
            weatherModel.TempLow = Math.Round(temps.Min(), 1).ToString();
            double chosenIcon = intIconCodes.Max();
            if (chosenIcon < 10)
            {
                weatherModel.Icon = GetIconClass("0" + intIconCodes.Max().ToString() + "d");
            }
            else
            {
                weatherModel.Icon = GetIconClass(intIconCodes.Max().ToString() + "d");
            }

            weatherModel.Day = weathers[0].Day;

            return weatherModel;
        }

        public static string GetIconClass(string iconCode)
        {
            string icon = "";
            switch (iconCode)
            {
                case ("01d"):
                    {
                        icon = "day-sunny";
                        break;
                    }
                case "02d":
                    {
                        icon = "day-sunny-overcast";
                        break;
                    }
                case "03d":
                    {
                        icon = "cloud";
                        break;
                    }
                case "04d":
                    {
                        icon = "cloudy";
                        break;
                    }
                case "09d":
                    {
                        icon = "showers";
                        break;
                    }
                case "10d":
                    {
                        icon = "rain";
                        break;
                    }
                case "11d":
                    {
                        icon = "thunderstorm";
                        break;
                    }
                case "13d":
                    {
                        icon = "snow";
                        break;
                    }
                case "50d":
                    {
                        icon = "fog";
                        break;
                    }

            }
            icon = "wi wi-" + icon;
            return icon;
        }
    }
}
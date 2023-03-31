//.......................................2.6.......................................

using System;
using System.IO;
using System.Net;

public class Program
{
    
    public  class Cloud
    {
        public string cloudInfo { get; }

        public Cloud(int cloud)
        {
            if (cloud >= 0 && cloud <= 3) this.cloudInfo = "Ясно";
            if (cloud >= 3 && cloud <= 7) this.cloudInfo = "Переменная облачность";
            if (cloud >= 8 && cloud <= 10) this.cloudInfo = "Пасмурно";
        }
    } 
    
    public class GetRequest
    {
        HttpWebRequest _request;
        string _address;

        public string Response { get; set; }

        public GetRequest(string address)
        {
            _address = address;
        }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();
            }
            catch(Exception)
            { 
            }

        }
    }
    
    public class Temp
    {
        public int temp { get; }
        public int feelsLike { get; }
        public int tempMin { get; }
        public int tempMax { get; }
        public int pressure { get; }
        public int humidity { get;  }

        public Temp(int temp, int feelsLike, int tempMin, int tempMax, int pressure, int humidity)
        {
            this.temp = temp - 273;
            this.feelsLike = feelsLike - 273;
            this.tempMin = tempMin - 273;
            this.tempMax = tempMax - 273;
            this.pressure = pressure;
            this.humidity = humidity;
        }
    }
    
    public class Wind
    {
        public int speed { get; }
        public string deg { get; }

        public Wind(int speed, int deg)
        {
            this.speed = speed;

            if (deg == 0 || deg == 360) this.deg = "Север";
            if (deg == 90) this.deg = "Восток";
            if (deg == 180) this.deg = "Юг";
            if (deg == 270) this.deg = "Запад";

            if (deg > 0 && deg < 90) this.deg = "Северо-Восток";
            if (deg > 90 && deg < 180) this.deg = "Юго-Восток";
            if (deg > 180 && deg < 270) this.deg = "Юго-Запад";
            if (deg > 270 && deg < 360) this.deg = "Северо-Запад";
        }
    }
    
    public static void Main()
    {
        var key = "11d6bb62d4cffe5e2e93a95d534cea5c";
        var lat = "56.5";
        var lon = "84.9667";
        var request = new GetRequest($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={key}");
        request.Run();

        var response = request.Response;

        var json = JObject.Parse(response);
        var temps = json["main"];

        Temp temp = new Temp((int)temps["temp"],
            (int)temps["feels_like"], 
            (int)temps["temp_min"], 
            (int)temps["temp_max"],
            (int)temps["pressure"],
            (int)temps["humidity"]);

        string town = (string)json["name"];

        Console.WriteLine($"Погода: {town}");

        Console.WriteLine($"Температура: {temp.temp}°C\n" +
                          $"Ощущается как: {temp.feelsLike}°C\n" +
                          $"Минимальная температура: {temp.tempMin}°C\n" +
                          $"Максимальная температура: {temp.tempMax}°C\n" +
                          $"Давление: {temp.pressure}мм рт.ст.\n" +
                          $"Влажность: {temp.humidity}%");

        var windInfo = json["wind"];
        Wind wind = new Wind((int)windInfo["speed"], 
            (int)windInfo["deg"]);

        Console.WriteLine($"Направление ветра: {wind.deg}\nСкорость ветра: {wind.speed} м/с");

        var cloudInfo = json["clouds"];
        Cloud cloud = new Cloud((int)cloudInfo["all"]);
        Console.WriteLine($"Облачность: {cloud.cloudInfo}");

        Console.Read();
    }
}
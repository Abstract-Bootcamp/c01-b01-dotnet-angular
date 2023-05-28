using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly List<string> Summaries = new List<string>
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet()]
    public string GetDictionaryValue(string key)
    {
        var di = new Dictionary<string, string>();

        di.Add("abc", "Freezing");
        di.Add("def", "Bracing");
        di.Add("ghi", "Chilly");
        di.Add("jkl", "Cool");
        di.Add("mno", "Mild");

        if (di.ContainsKey(key))
        {
            return di[key];// O(1)
        }

        return "Not Found";
    }


    [HttpGet()]
    public string GetByName(string summary)
    {
        if (!Summaries.Any())
        {
            return string.Empty;
        }

        return Summaries.FirstOrDefault(s => s.ToLower() == summary.ToLower());

        // foreach (var s in Summaries)
        // {
        //     if (s.ToLower() == summary.ToLower())
        //     {
        //         return s;
        //     }
        // }

        // return string.Empty; // = ""
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        // object a = 1;// boxing

        // int b = (int)a;// unboxing
        // int.Parse(a);
        // int.TryParse(a, out b);
        // var c = a as int;

        // var w = new List<int>();
        // w.Add(new WeatherForecast());

        return null;
    }
}

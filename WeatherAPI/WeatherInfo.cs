using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI
{
    public class WeatherInfo
    {
        public string resultcode { get; set; }
        public string reason { get; set; }

        public Result result { get; set; }
        //public List<Result> result { get; set; }
    }
    public class Result
    {
        public SK sk { get; set; }
    }

    public class SK
    {
        public int temp { get; set; }
        public string wind_direction { get; set; }
        public string wind_strength { get; set; }
        public string humidity { get; set; }
        public string time { get; set; }
    }
}

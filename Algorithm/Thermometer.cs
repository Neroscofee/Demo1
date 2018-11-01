using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Thermometer
    {
        private double temperature;
        public Thermometer(double temperature)
        {
            this.temperature = temperature;
        }
        public double Temperature
        {
            get { return temperature-273.15; }
            set { temperature = value+273.15; }
        }
    }
}

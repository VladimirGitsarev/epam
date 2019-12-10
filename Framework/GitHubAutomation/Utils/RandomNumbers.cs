using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyuiaTestFramework.Utils
{
    class RandomNumbers
    {
        public static string FlightNumber()
        {
            Random random = new Random();
            string flightNumber = random.Next(1000, 10000).ToString();
            return flightNumber;
        }
    }
}

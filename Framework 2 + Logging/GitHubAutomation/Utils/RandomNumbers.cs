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

        public static string RandomString(int Length)
        {
            string Alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm123456789";
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(Length - 1);
            int Position = 0;
            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                sb.Append(Alphabet[Position]);
            }
            return sb.ToString();
        }
    }
}

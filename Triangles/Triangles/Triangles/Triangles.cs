using System;

namespace Triangles
{
    public class Triangle
    {
        public static bool IsTriangle(int a, int b, int c) =>
            (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

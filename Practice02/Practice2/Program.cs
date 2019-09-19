using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public struct PointS
    {
        public int X;
        public int Y;
    }


    class PointC
    {
        public int X;
        public int Y;

        public static PointC operator +(PointC p1, PointC p2)
        {
            var result = new PointC();
            result.X = p1.X + p2.X;
            result.Y = p1.Y + p2.Y;
            return result;
        }

        public static PointC operator +(PointC p1, int p2)
        {
            var result = new PointC();
            result.X = p1.X + p2;
            result.Y = p1.Y + p2;
            return result;
        }

        public static PointC operator +(int p2, PointC p1)
        {
            var result = new PointC();
            result.X = p1.X + p2;
            result.Y = p1.Y + p2;
            return result;
        }

        public override string ToString()
        {
            return $"({X};{Y})";
        }
    }

    class Program
    {
        static void MS(PointS p)
        {
            p.X = 10;
        }

        static void MC(PointC p)
        {
            p.X = 10;
        }


        static void Main(string[] args)
        {
            PointS pS = new PointS();
            PointC pC = new PointC();
            Console.WriteLine(pS.X);
            Console.WriteLine(pC.X);
            pS.X = 5;
            pC.X = 5;
            Console.WriteLine(pS.X);
            Console.WriteLine(pC.X);
            MS(pS);
            MC(pC);
            Console.WriteLine(pS.X);
            Console.WriteLine(pC.X);

            var p1 = new PointC() { X = 1, Y = 2 };
            var p2 = new PointC() { X = 6, Y = 4 };
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p1 + p2);
            Console.WriteLine(6 + p1);
        }
    }
}

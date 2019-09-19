using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice02
{
    struct PointS
    {
        public int X;
        public int Y;
        public int Z;
    }



    class PointC
    {
        public int X;
        public int Y;
        public int Z;
        public PointC()
        {

        }

        public static PointC operator +(PointC p1, PointC p2)
        {
            return new PointC() { X = p1.X + p2.X, Y = p1.Y + p2.Y };
        }

        public static PointC operator +(PointC p1, int p2)
        {
            return new PointC() { X = p1.X + p2, Y = p1.Y + p2 };
        }

        public static PointC operator +(int p2, PointC p1)
        {
            return new PointC() { X = p1.X + p2, Y = p1.Y + p2 };
        }

        public override string ToString()
        {
            return $"({X};{Y})";
        }
    }

    class Program
    {


        static void MS(ref PointS p)
        {
            p.X = 10;
        }

        static void MC(PointC p)
        {
            p.X = 10;
        }
        static void Main(string[] args)
        {
            PointS p1 = new PointS();
            PointC p2 = new PointC();
            Console.WriteLine(p1.X);
            Console.WriteLine(p2.X);
            p1.X = 5;
            p2.X = 5;
            Console.WriteLine(p1.X);
            Console.WriteLine(p2.X);
            MS(ref p1);
            MC(p2);
            Console.WriteLine(p1.X);
            Console.WriteLine(p2.X);

            //PointS[] aS = new PointS[1000000000];
            //PointC[] aC = new PointC[1000000000];

            var p3 = new PointC { X = 1, Y = 3 };
            var p4 = new PointC { X = 5, Y = 8 };
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.WriteLine(p3 + p4);
            Console.WriteLine(10 + p3);
        }
    }
}

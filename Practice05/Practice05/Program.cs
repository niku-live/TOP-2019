using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice05
{

    class Parent
    {
        public Parent() { }
    }

    class ConstructorExample : Parent
    {
        int _a, _b, _c, _d, _e;

        public ConstructorExample(int a, int b, int c, int d, int e) : this(a, b, c)
        {
            _d = d;
            _e = e;
        }


        public ConstructorExample(int a, int b, int c) : base()
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public ConstructorExample()
        {

        }
    }

    struct ExStruct
    {
        public int A;

        public override string ToString() => A.ToString();
       
    }


    class Program
    {
        static void Main(string[] args)
        {
            short s = 5;
            int d = int.MaxValue;
            d = s;
            /*
            checked
            {
                s = (short)d;
            }*/

            int a1 = 5;
            int a2 = 6;

            a1 = a2;
            a1 = 10;

            Console.WriteLine(a1);
            Console.WriteLine(a2);

            object o1 = a1;
            object o2 = a2;

            o1 = o2;
            o1 = 10;
            //a1 = 10;
            Console.WriteLine(o1);
            Console.WriteLine(o2);

            ExStruct s1 = new ExStruct() { A = 5 };
            ExStruct s2 = new ExStruct() { A = 6 };

            o1 = s1;
            o2 = s2;

            o1 = o2;
            s2.A = 10;

            Console.WriteLine(o1);
            Console.WriteLine(o2);

        }
    }
}

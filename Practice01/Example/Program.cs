using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program : IProgram
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 10;
            int c = 10;
            ReadAndPrintHello(1);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(a);
            Console.ReadLine();
        }

        public void Test()
        {
            int a = 15;
            int b = 15;
            int c = 15;
        }

        private static void ReadAndPrintHello(int c)
        {
            string textLine = Console.ReadLine();
            int b = 30;
            Console.WriteLine("Labas, pasauli!!!!");
            Console.WriteLine(textLine);
        }
    }
}

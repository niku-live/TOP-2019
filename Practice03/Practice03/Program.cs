using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice03
{
    class Program
    {

        static void Method1(string param1, string defaultPrefix, string param3 = "", string param4 = "")
        {

        }

        static void Main(string[] args)
        {
            Method1("", "", "");
            Method1("", "");
            Method1("", "", param4: "");
            Method1("", defaultPrefix: "");

            List<string> stringList = new List<string>();
            List<int> intList = new List<int>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string test3 = "";
            int test = 0;

            ArrayList list3 = new ArrayList();
            list3.Add(test);
            list3.Add(test3);
            test = (int)list3[0];

            List<int> list2 = new List<int>();
            list2.Add(test);
            //Not allowed list2.Add(test3);
            test = list2[0];

        }
    }
}

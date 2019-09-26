using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice03
{
    class Demo
    {
        private string Field = "DefaultValue";

        public string GetField() { return Field; }
        public void SetField(string value) { Field = value; }

        public string Property { get { return Field; } set { Field = value; } }

        public string AutoProperty { get; set; } = "AutoDefaultValue";

        public int this[int index]
        {
            get { return index * 5; }
            set { Field += $"|Index: {index}; Value: {value}|"; }
        }

        public string this[string name]
        {
            get { return name; }
        }

        public int this[int index1, int index2]
        {
            get { return index1 * index2; }
        }

        public void TestMethod(string initValue, string defaultPrefix, string dataSource = "", string argumentString = "")
        {

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();
            Console.WriteLine(demo.GetField());
            Console.WriteLine(demo.Property);
            Console.WriteLine(demo.AutoProperty);

            demo.Property = "Test";
            demo.SetField("Test3");
            demo.AutoProperty = "Test2";
            Console.WriteLine(demo.GetField());
            Console.WriteLine(demo.Property);
            Console.WriteLine(demo.AutoProperty);

            Console.WriteLine(demo[5]);
            demo[5] = 15;
            demo[4] = 10;
            Console.WriteLine(demo.GetField());
            Console.WriteLine(demo["Test"]);
            Console.WriteLine(demo[2, 3]);

            demo.TestMethod("", "", "", "");
            demo.TestMethod("", "", "");
            demo.TestMethod("", "");
            demo.TestMethod("", defaultPrefix: "", "", "");
            demo.TestMethod("", "", argumentString: "");
            demo.TestMethod(initValue: "", defaultPrefix: "");
            demo.TestMethod(defaultPrefix: "", initValue: "");

            Dictionary<int, string> d = new Dictionary<int, string>();

            List<int> l = new List<int>();
            List<string> l2 = new List<string>();
            ArrayList l3 = new ArrayList();

            string test1 = "";
            int test2 = 10;

            l3.Add(test1);
            l3.Add(test2);

            l2.Add(test1);
            //l2.Add(test2);

            test1 = (string)l3[0];
            test1 = l2[0];
            //test1 = l[0];
        }
    }
}

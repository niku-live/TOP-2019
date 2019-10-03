using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice04
{
    class FileDataStorage : IDataStorage
    {
        public IEnumerable<int> Numbers { get => ReadFromFile(); }

        private IEnumerable<int> ReadFromFile()
        {
            return new List<int>() { 1, 3, 4, 5 };
        }
    }

    class SqlDataStorage : IDataStorage
    {
        public IEnumerable<int> Numbers { get => ReadFromSql(); }

        private IEnumerable<int> ReadFromSql()
        {
            return new List<int>() { 1, 3, 4, 5 };
        }
    }

    class BadCalculator
    {
        private FileDataStorage dataStorage = new FileDataStorage();
        public int CalculateSum()
        {
            return dataStorage.Numbers.Sum();
        }
    }

    class Calculator
    {
        private IDataStorage dataStorage;

        public Calculator(IDataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }


        public int CalculateSum()
        {
            return dataStorage.Numbers.Sum();
        }
    }

    class Calculator2
    {
        private IDataStorage dataStorage;
        public IDataStorage DataStorage { get => dataStorage; set => dataStorage = value; }


        public Calculator2()
        {
        }

        public int CalculateSum()
        {
            return dataStorage.Numbers.Sum();
        }
    }

    class Calculator3
    {
        public Calculator3()
        {
        }

        public int CalculateSum(IDataStorage dataStorage)
        {
            return dataStorage.Numbers.Sum();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BadCalculator calc = new BadCalculator();
            Console.WriteLine(calc.CalculateSum());

            Calculator calc2 = new Calculator(new FileDataStorage());
            Console.WriteLine(calc2.CalculateSum());

            Calculator2 calc3 = new Calculator2();
            calc3.DataStorage = new FileDataStorage();
            Console.WriteLine(calc3.CalculateSum());

            Calculator3 calc4 = new Calculator3();
            Console.WriteLine(calc4.CalculateSum(new FileDataStorage()));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice04
{
    class FileDataStorage : IDataStorage
    {
        public IEnumerable<int> Numbers { get { return ReadFromFile(); } }

        private IEnumerable<int> ReadFromFile()
        {
            //Fake read from file
            return new List<int>() { 1, 2, 3, 4 };
        }

    }

    class SqlDataStorage : IDataStorage
    {
        public IEnumerable<int> Numbers { get { return ReadFromSql(); } }

        private IEnumerable<int> ReadFromSql()
        {
            //Fake read from sql
            return new List<int>() { 1, 2, 3, 4 };
        }
    }


    class BadCalculator
    {
        private SqlDataStorage _storage;

        public BadCalculator()
        {
            _storage = new SqlDataStorage();
        }

        public int CalculateSum()
        {
            return _storage.Numbers.Sum();
        }

    }


    class Calculator
    {
        private IDataStorage _storage;

        public Calculator(IDataStorage storageImpl)
        {
            _storage = storageImpl;
        }

        public int CalculateSum()
        {
            return _storage.Numbers.Sum();
        }

    }

    class Calculator2
    {
        public IDataStorage Storage { get; set;  }

        public Calculator2()
        {
        }

        public int CalculateSum()
        {
            return Storage.Numbers.Sum();
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
            var badCalc = new BadCalculator();
            Console.WriteLine(badCalc.CalculateSum());

            var calc = new Calculator(new FileDataStorage());
            Console.WriteLine(calc.CalculateSum());

            var calc2 = new Calculator2();
            calc2.Storage = new FileDataStorage();
            Console.WriteLine(calc2.CalculateSum());

            var calc3 = new Calculator3();
            Console.WriteLine(calc3.CalculateSum(new FileDataStorage()));
        }
    }
}

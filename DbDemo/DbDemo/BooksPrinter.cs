using System;
using System.Collections.Generic;
using System.Text;

namespace DbDemo
{
    public static class BooksPrinter
    {
        public static void PrintBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}

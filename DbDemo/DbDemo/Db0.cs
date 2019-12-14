using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DbDemo
{
    public class Db0
    {
        public void MethodsDemo()
        {
            ExtremelyBadDemo();
        }

        private void ExtremelyBadDemo()
        {
            SqlConnection connection = new SqlConnection(GlobalConfig.ConnectionString);
            connection.Open();

            var cmd = new SqlCommand("SELECT COUNT(*) FROM Stud.Knyga", connection);
            int count = (int)cmd.ExecuteScalar();
            Console.WriteLine($"{count}");

            cmd = new SqlCommand("SELECT * FROM Stud.Knyga", connection);

            var reader = cmd.ExecuteReader();
            var books = new List<Book>();
            while (reader.Read())
            {
                books.Add(new Book()
                {
                    ISBN = reader.GetString(0),
                    Title = reader.GetString(1),
                    Publisher = reader.GetString(2),
                    Year = reader.GetInt16(3),
                    PageCount = reader.GetInt16(4),
                    Price = reader.IsDBNull(5) ? (decimal?)null : reader.GetDecimal(5)
                });
            }
            reader.Close();
            BooksPrinter.PrintBooks(books);


            var book = new Book()
            {
                ISBN = "9997-03-303-6",
                Title = "Informacines sistemos 2",
                Publisher = "Raudonoji",
                Year = 2006,
                PageCount = 254,
                Price = 15.5m
            };

            cmd = new SqlCommand("INSERT INTO [Stud].[Knyga]'+" +
            "([ISBN],[Pavadinimas],[Leidykla],[Metai],[Puslapiai],[Verte])" +
            "VALUES ('" + book.ISBN + "', '" + book.Title + "', '" + book.Publisher + "', " +
            book.Year.ToString() + ", " + book.PageCount.ToString() + ", " + book.Price.ToString().Replace(",", ".") + ")",
            connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }


    }
}

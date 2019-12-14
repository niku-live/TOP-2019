using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DbDemo
{
    public class Db1
    {
        public void MethodsDemo()
        {
            BadDemo();
            //BetterDemo();
        }

        private void BadDemo()
        {
            SqlConnection sqlConnection = new SqlConnection(GlobalConfig.ConnectionString);
            sqlConnection.Open();

            int count = GetBookCount(sqlConnection);
            Console.WriteLine($"{count}");


            BooksPrinter.PrintBooks(GetBooks(sqlConnection));


            var book = new Book()
            {
                ISBN = "9997-03-303-6",
                Title = "Informacines sistemos 2",
                Publisher = "Raudonoji",
                Year = 2006,
                PageCount = 254,
                Price = 15.5m
            };

            AddBook(book, sqlConnection);
            sqlConnection.Close();
        }

        private void BetterDemo()
        {
            using (var sqlConnection = new SqlConnection(GlobalConfig.ConnectionString))
            {
                sqlConnection.Open();
                int count = GetBookCount(sqlConnection);
                Console.WriteLine($"{count}");


                BooksPrinter.PrintBooks(GetBooks(sqlConnection));


                var book = new Book()
                {
                    ISBN = "9997-03-303-6",
                    Title = "Informacines sistemos 2",
                    Publisher = "Raudonoji",
                    Year = 2006,
                    PageCount = 254,
                    Price = 15.5m
                };

                AddBook(book, sqlConnection);
            }
        }


        private int GetBookCount(SqlConnection connection)
        {
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Stud.Knyga", connection);
            return (int)cmd.ExecuteScalar();
        }

        private IEnumerable<Book> GetBooks(SqlConnection connection)
        {
            var cmd = new SqlCommand("SELECT * FROM Stud.Knyga", connection);

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
            return books;
        }


        private void AddBook(Book book, SqlConnection connection)
        {
            //AddBookAsBadAsItCouldGetSolution(book, connection);
            //AddBookReallyBadSolution(book, connection);
            //AddBookJustBadSolution(book, connection);
        }

        private void AddBookAsBadAsItCouldGetSolution(Book book, SqlConnection connection)
        {
            var cmd = new SqlCommand("INSERT INTO [Stud].[Knyga]'+" +
            "([ISBN],[Pavadinimas],[Leidykla],[Metai],[Puslapiai],[Verte])"+
            "VALUES ('" + book.ISBN + "', '" + book.Title + "', '" + book.Publisher + "', " +
            book.Year.ToString() + ", " + book.PageCount.ToString() + ", " + book.Price.ToString().Replace(",", ".") + ")", 
            connection);
            cmd.ExecuteNonQuery();

        }

        private void AddBookReallyBadSolution(Book book, SqlConnection connection)
        {
            //book.Title = "Receptai', '', 0, 0, 0);DELETE FROM [Stud.Knyga];--";

            var cmd = new SqlCommand($@"
INSERT INTO [Stud].[Knyga]
           ([ISBN]
           ,[Pavadinimas]
           ,[Leidykla]
           ,[Metai]
           ,[Puslapiai]
           ,[Verte])
     VALUES
           ('{book.ISBN}'
           ,'{book.Title}'
           ,'{book.Publisher}'
           ,{book.Year}
           ,{book.PageCount}
           ,{book.Price.ToString().Replace(",", ".")})",
connection);

            cmd.ExecuteNonQuery();

        }

        private void AddBookJustBadSolution(Book book, SqlConnection connection)
        {
            var cmd = new SqlCommand(@"
INSERT INTO [Stud].[Knyga]
           ([ISBN]
           ,[Pavadinimas]
           ,[Leidykla]
           ,[Metai]
           ,[Puslapiai]
           ,[Verte])
     VALUES
           (@isbn
           ,@title
           ,@publisher
           ,@year
           ,@pageCount
           ,@price)",
connection);
            cmd.Parameters.AddWithValue("@isbn", book.ISBN);
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@publisher", book.Publisher);
            cmd.Parameters.AddWithValue("@year", book.Year);
            cmd.Parameters.AddWithValue("@pageCount", book.PageCount);
            cmd.Parameters.AddWithValue("@price", book.Price);

            cmd.ExecuteNonQuery();
        }

    }
}

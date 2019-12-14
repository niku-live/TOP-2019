using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DbDemo
{
    public class Db2
    {
        public void MethodsDemo()
        {
            BetterDemo();
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

        private SqlDataAdapter CreateAdapter(SqlConnection connection)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(@"
SELECT [ISBN]
      ,[Pavadinimas]
      ,[Leidykla]
      ,[Metai]
      ,[Puslapiai]
      ,[Verte]
  FROM [biblio].[Stud].[Knyga]
", connection);


            //            dataAdapter.InsertCommand = new SqlCommand(@"
            //INSERT INTO [Stud].[Knyga]
            //           ([ISBN]
            //           ,[Pavadinimas]
            //           ,[Leidykla]
            //           ,[Metai]
            //           ,[Puslapiai]
            //           ,[Verte])
            //     VALUES
            //           (@isbn
            //           ,@title
            //           ,@publisher
            //           ,@year
            //           ,@pageCount
            //           ,@price)",
            //connection);

            //            dataAdapter.InsertCommand.Parameters.Add("@isbn", System.Data.SqlDbType.Char, 13, "ISBN");
            //            dataAdapter.InsertCommand.Parameters.Add("@title", System.Data.SqlDbType.VarChar, 32, "Pavadinimas");
            //            dataAdapter.InsertCommand.Parameters.Add("@publisher", System.Data.SqlDbType.Char, 12, "Leidykla");
            //            dataAdapter.InsertCommand.Parameters.Add("@year", System.Data.SqlDbType.SmallInt, 0, "Metai");
            //            dataAdapter.InsertCommand.Parameters.Add("@pageCount", System.Data.SqlDbType.SmallInt, 0, "Puslapiai");
            //            dataAdapter.InsertCommand.Parameters.Add("@price", System.Data.SqlDbType.Decimal, 0, "Verte");

            //            dataAdapter.UpdateCommand = new SqlCommand(@"
            //UPDATE [Stud].[Knyga]
            //    SET [Pavadinimas] = @title,
            //        [Leidykla] = @publisher
            //        [Metai] = @year
            //        [Puslapiai] = @pageCount
            //        [Verte] = @price
            //     WHERE
            //        [ISBN] = @isbn",
            //connection);

            //            dataAdapter.UpdateCommand.Parameters.Add("@isbn", System.Data.SqlDbType.Char, 13, "ISBN");
            //            dataAdapter.UpdateCommand.Parameters.Add("@title", System.Data.SqlDbType.VarChar, 32, "Pavadinimas");
            //            dataAdapter.UpdateCommand.Parameters.Add("@publisher", System.Data.SqlDbType.Char, 12, "Leidykla");
            //            dataAdapter.UpdateCommand.Parameters.Add("@year", System.Data.SqlDbType.SmallInt, 0, "Metai");
            //            dataAdapter.UpdateCommand.Parameters.Add("@pageCount", System.Data.SqlDbType.SmallInt, 0, "Puslapiai");
            //            dataAdapter.UpdateCommand.Parameters.Add("@price", System.Data.SqlDbType.Decimal, 0, "Verte");

            //            dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM [Stud].[Knyga] WHERE [ISBN] = @isbn", connection);
            //            dataAdapter.DeleteCommand.Parameters.Add("@isbn", System.Data.SqlDbType.Char, 13, "ISBN");

            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.DeleteCommand = builder.GetDeleteCommand();
            dataAdapter.InsertCommand = builder.GetInsertCommand();
            dataAdapter.UpdateCommand = builder.GetUpdateCommand();
            return dataAdapter;
        }

        private int GetBookCount(SqlConnection connection)
        {
            var adapter = CreateAdapter(connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable.Rows.Count;
        }

        private IEnumerable<Book> GetBooks(SqlConnection connection)
        {
            var books = new List<Book>();
            var adapter = CreateAdapter(connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                books.Add(new Book()
                {
                    ISBN = row.Field<string>("ISBN"),
                    Title = row.Field<string>("Pavadinimas"),
                    Publisher = row.Field<string>("Leidykla"),
                    Year = row.Field<Int16>("Metai"),
                    PageCount = row.Field<Int16>("Puslapiai"),
                    Price = row.Field<decimal?>("Verte")
                });
            }
            return books;
        }


        private void AddBook(Book book, SqlConnection connection)
        {
            var adapter = CreateAdapter(connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            var row = dataTable.NewRow();
            row["ISBN"] = book.ISBN;
            row["Pavadinimas"] = book.Title;
            row["Leidykla"] = book.Publisher;
            row["Metai"] = book.Year;
            row["Puslapiai"] = book.PageCount;
            row["Verte"] = book.Price;
            dataTable.Rows.Add(row);


            adapter.Update(dataTable);
        }

    }
}

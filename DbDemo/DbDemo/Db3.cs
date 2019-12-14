using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DbDemo
{
    public class Db3
    {
        public void MethodsDemo()
        {
            BestDemo();
        }

        class BiblioDbContext: DbContext
        {
            public DbSet<Book> Books { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(GlobalConfig.ConnectionString);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Book>().ToTable("Knyga", "Stud");
            }
        }


        private void BestDemo()
        {
            using (var context = new BiblioDbContext())
            { 
                int count = GetBookCount(context);
                Console.WriteLine($"{count}");


                BooksPrinter.PrintBooks(GetBooks(context));


                var book = new Book()
                {
                    ISBN = "9997-03-303-6",
                    Title = "Informacines sistemos 2",
                    Publisher = "Raudonoji",
                    Year = 2006,
                    PageCount = 254,
                    Price = 15.5m
                };

                AddBook(book, context);
            }
        }

        private int GetBookCount(BiblioDbContext context)
        {
            return context.Books.CountAsync().Result;
        }

        private IEnumerable<Book> GetBooks(BiblioDbContext context)
        {
            return context.Books;
        }


        private void AddBook(Book book, BiblioDbContext context)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

    }
}

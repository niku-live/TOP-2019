using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbDemo
{
    public class Book
    {
        [Column(TypeName="char(13)")]
        [Key]
        public string ISBN { get; set; }
        [Column("Pavadinimas", TypeName = "varchar(32)")]
        public string Title { get; set; }
        [Column("Leidykla", TypeName ="char(12)")]
        public string Publisher { get; set; }
        [Column("Metai", TypeName ="smallint")]
        public int Year { get; set; }
        [Column("Puslapiai", TypeName ="smallint")]
        public int PageCount { get; set; }
        [Column("Verte", TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }

        public override string ToString() => $"{ISBN}: {Title}";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DbDemo
{
    public static class GlobalConfig
    {
        public static string ConnectionString { get => "Server=localhost\\sqlexpress;Database=biblio;Trusted_Connection=True;"; }
    }
}

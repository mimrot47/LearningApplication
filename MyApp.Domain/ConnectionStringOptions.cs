using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain
{
    public class ConnectionStringOptions
    {
        public const string SectionsName = "ConnectionStrings";

        public string? DefaultConnection { get; set; }
    }
}

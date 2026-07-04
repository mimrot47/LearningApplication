using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infrastrature.Percestency
{
    public class MyAppDbcontext:DbContext
    {
        public MyAppDbcontext(DbContextOptions<MyAppDbcontext> options):base(options) {

        }
        public DbSet<MyEnployees> MyEmployees { get; set; }
    }
}

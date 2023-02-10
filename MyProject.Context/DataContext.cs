using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Entities;

namespace MyProject.Context
{
    public class DataContext : DbContext, IContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
           "Server=(localdb)\\mssqllocaldb;Database=MyProjectDB;Trusted_Connection=True;");
        }
    }
}

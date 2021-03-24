using BankingApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace BankingApplication.Services
{
    class PersonContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.useSqlServer(@"Server=tcp:year4xamarinsqlserver.database.windows.net,1433;Initial Catalog=Year4XamarinSQLDatabase;Persist Security Info=False;User ID=JBYear4;Password=Gamestop8991!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public DbSet<Person> people { get; set; }
    }
}

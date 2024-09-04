using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess
{
    internal class CashFlowDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=cashflowdb;user=root;Password=adminadmin;";
            var version = new Version(9, 0, 1);
            var serverVersion = new MySqlServerVersion(version);
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}

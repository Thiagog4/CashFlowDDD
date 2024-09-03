using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess
{
    internal class CashFlowDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=root@127.0.0.1:3306;Database=cashflowdb;Uid=root;Pwd=adminadmin;";
            var serverVersion = new MySqlServerVersion(new Version(8, 4, 2));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}

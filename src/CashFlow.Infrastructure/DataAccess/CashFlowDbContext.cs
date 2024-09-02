﻿using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess
{
    public class CashFlowDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connectionString = "Server=localhost;Database=CashFlow;Trusted_Connection=True;";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}

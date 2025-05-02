using BankRequest.Domain.Core.Entites;
using BankRequest.Infra.SqlServer.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankRequest.Infra.SqlServer.Common
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ShebaRequestConfiguration());
            builder.ApplyConfiguration(new AccountConfiguration());
            base.OnModelCreating(builder);

        }

        public DbSet<ShebaRequest> ShebaRequests { get; set; }
        public DbSet<Domain.Core.Entites.Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}

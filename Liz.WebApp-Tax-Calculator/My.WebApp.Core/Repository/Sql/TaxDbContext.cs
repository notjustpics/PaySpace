using Microsoft.EntityFrameworkCore;
using My.WebApp.Core.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.WebApp.Core.Repository.Sql
{
    public class TaxDbContext : DbContext
    {
        public TaxDbContext()
        {

        }

        public TaxDbContext(DbContextOptions<TaxDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=.;Database=TaxCalculator;Trusted_Connection=True;MultipleActiveResultSets=true");
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-2R0JUQO\LIZ;Database=TaxCalculator;Trusted_Connection=True;MultipleActiveResultSets=true");
                //DESKTOP-2R0JUQO\LIZ
            }
        }

        public DbSet<LupRate> LupRate { get; set; }
        public DbSet<LupCalculationType> LupCalculationType { get; set; }
        public DbSet<LupPostalCode> LupPostalCode { get; set; }
        public DbSet<TaxCalculation> TaxCalculation { get; set; }
    }
}

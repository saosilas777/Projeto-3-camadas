using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface.UnitOfWork;

namespace Data.Context
{
    public class DbSilasContext : DbContext, IUnitOfWork
    {
        public DbSilasContext(DbContextOptions<DbSilasContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public async Task<bool> Commit()
        {
            bool success = await base.SaveChangesAsync() > 0;
            return success;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conn = @"Server = DESKTOP-51DGK9C; Database = SilasDB01; Trusted_Connection = True";
                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface.UnitOfWork;
using Domain.Entity.Util;
using Domain.Entity;

namespace Data.Context
{
    public class DbSilasContext : DbContext, IUnitOfWork
    {
        public DbSilasContext()
        {

        }

        public DbSilasContext(DbContextOptions<DbSilasContext> dbContextOptions) : base(dbContextOptions)
        {
        }
               


        public DbSet<Logger> Logger { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Users> Users { get; set; }


        public async Task<bool> Commit()
        {
            bool success = await base.SaveChangesAsync() > 0;
            return success;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string conn = @"Server=DESKTOP-51DGK9C;Database=DbSilas;User Id=sa;Password=102030";
                string conn = @"Server=DESKTOP-SPGKM46;Database=DbSilas;User Id=Silas;Password=102030";
                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbSilasContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            var stringProperties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(_ => _.GetProperties())
                .Where(_ => _.ClrType == typeof(string) && _.GetColumnType() == null);

            foreach (var item in stringProperties)
            {
                item.SetIsUnicode(false);
                if (item.GetMaxLength() == null)
                    item.SetMaxLength(256);
            }

            var decimalProperties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(_ => _.GetProperties())
                .Where(_ => (_.ClrType == typeof(decimal) || _.ClrType == typeof(decimal?)) && _.GetColumnType() == null);

            foreach (var item in decimalProperties)
            {
                if (item.GetPrecision() == null && item.GetScale() == null)
                {
                    item.SetPrecision(18);
                    item.SetScale(4);
                }
            }


            base.OnModelCreating(modelBuilder);

        }

    }
}

using Microsoft.EntityFrameworkCore;
using Modelo.Security.DataAcces.ModelConfigurations;
using Modelo.Security.Models;

namespace Modelo.Security.DataAcces
{
    public class DbSecurityContext : DbContext
    {

        public DbSecurityContext(DbContextOptions<DbSecurityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();

            modelBuilder.HasSequence<int>("tbl_company_Id_seq")
                .StartsAt(1000)
                .IncrementsBy(5);

            modelBuilder.Entity<tbl_company>()
                .Property(o => o.Id)
                .HasDefaultValueSql("nextval('\"tbl_company_Id_seq\"')");
               
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

        }

        public DbSet<tbl_company> tbl_company { get; set; }
        public DbSet<tbl_user> tbl_user { get; set; }

    }
}

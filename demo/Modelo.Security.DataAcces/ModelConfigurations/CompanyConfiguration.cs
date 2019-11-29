using Microsoft.EntityFrameworkCore;
using System;
using Modelo.Security.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modelo.Security.DataAcces.ModelConfigurations
{
   public  class CompanyConfiguration : IEntityTypeConfiguration<tbl_company>
    {
        public void Configure(EntityTypeBuilder<tbl_company> builder)
        {

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(prop => prop.Password)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(prop => prop.BusinessName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(prop => prop.IsActive)
                .IsRequired();
        }
    }
}

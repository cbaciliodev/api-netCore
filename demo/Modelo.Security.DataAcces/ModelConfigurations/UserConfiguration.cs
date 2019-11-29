using System;
using Modelo.Security.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Modelo.Security.DataAcces.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<tbl_user>
    {
        public void Configure(EntityTypeBuilder<tbl_user> builder)
        {

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(prop => prop.Password)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(prop => prop.PersonName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(prop => prop.IsActive)
                .IsRequired();

        }
    }
}

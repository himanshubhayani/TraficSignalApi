using Test.data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.data.Mapping
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<Users> entity)
        {
            entity.ToTable("Users");

            entity.HasKey(m => m.Id);
            entity.Property(t => t.Email).HasColumnName(@"Email").IsRequired().HasColumnType("varchar(max)");
            entity.Property(t => t.FirstName).HasColumnName(@"FirstName").HasColumnType("varchar(100)");
            entity.Property(t => t.LastName).HasColumnName(@"LastName").HasColumnType("varchar(100)");
            entity.Property(t => t.Password).HasColumnName(@"Password").IsRequired().HasColumnType("varchar(max)");
            entity.Property(t => t.IsActive).HasColumnName(@"IsActive").IsRequired().HasColumnType("bit").HasDefaultValueSql("1");
        }
    }
}

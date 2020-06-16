using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebAppCodeFirst.Models
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            HasKey(c => c.Id);

            Property(c => c.Name).HasMaxLength(256).IsRequired();
            Property(c => c.AccountName).HasMaxLength(256).IsRequired();
            Property(c => c.Password).HasMaxLength(256).IsRequired();
            Property(c => c.Email).HasMaxLength(256);
            Property(c => c.Phone).HasMaxLength(256);

            Property(c => c.CreateDate).IsRequired();
            Property(c => c.CreateUser).HasMaxLength(256);
            //Property(c => c.UpdateDate);
            Property(c => c.UpdateUser).HasMaxLength(128);
        }
    }
}
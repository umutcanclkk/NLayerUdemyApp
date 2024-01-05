using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SurName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.E_Mail).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(15);

            // Eğer müşterilerin bir kategorisi varsa:
            // builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

            // Eğer müşterilerin bir ödemesi varsa:
            //  builder.HasMany(x => x.Payments).WithOne().HasForeignKey(x => x.CustomerId);

            builder.ToTable("Customers");
        }
    }
}

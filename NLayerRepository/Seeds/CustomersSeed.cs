using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class CustomersSeed : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasData(
            // 1. Örnek
         new Customers
         {
             Id = 1,
             Name = "John",
             SurName = "Doe",
             E_Mail = "john.doe@example.com",
             PhoneNumber = " 123456789"
         },

            // 2. Örnek
           new Customers
           {
               Id = 2,
               Name = "Jane",
               SurName = "Smith",
               E_Mail = "jane.smith@example.com",
               PhoneNumber = "987654321"
           },

            // 3. Örnek
            new Customers
            {
                Id = 3,
                Name = "Alice",
                SurName = "Johnson",
                E_Mail = "alice.johnson@example.com",
                PhoneNumber = " 555555555"
            },

            // 4. Örnek
             new Customers
             {
                 Id = 4,
                 Name = "Bob",
                 SurName = "Williams",
                 E_Mail = "bob.williams@example.com",
                 PhoneNumber = "777777777"
             },

            // 5. Örnek
            new Customers
            {
                Id = 5,
                Name = "Eve",
                SurName = "Taylor",
                E_Mail = "eve.taylor@example.com",
                PhoneNumber = " 999999999"
            },

            // 6. Örnek
            new Customers
            {
                Id = 6,
                Name = "Michael",
                SurName = "Johnson",
                E_Mail = "michael.johnson@example.com",
                PhoneNumber = "111111111"
            },

            // 7. Örnek
            new Customers
            {
                Id = 7,
                Name = "Emily",
                SurName = "Davis",
                E_Mail = "emily.davis@example.com",
                PhoneNumber = " 222222222"
            },

            // 8. Örnek
           new Customers
           {
               Id = 8,
               Name = "Daniel",
               SurName = "Brown",
               E_Mail = "daniel.brown@example.com",
               PhoneNumber = "333333333"
           },

            // 9. Örnek
            new Customers
            {
                Id = 9,
                Name = "Olivia",
                SurName = "Miller",
                E_Mail = "olivia.miller@example.com",
                PhoneNumber = " 444444444"
            },

            // 10. Örnek
         new Customers
         {
             Id = 10,
             Name = "William",
             SurName = "Clark",
             E_Mail = "william.clark@example.com",
             PhoneNumber = "555555555"
         });
            
            

        }
    }
}

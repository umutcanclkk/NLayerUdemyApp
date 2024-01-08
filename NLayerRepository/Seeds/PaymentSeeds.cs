using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class PaymentSeeds : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // Örnek 1
            builder.HasData(new Payment
            {
                Id = 1,
                PaymentMethod = "Kredi Kartı",
                Amount = 100.50m,
                Date = DateTime.Now,
                TransactionId = "ABC123"
            },

            // Örnek 2
            new Payment
            {
                Id = 2,
                PaymentMethod = "Nakit",
                Amount = 50.75m,
                Date = DateTime.Now.AddDays(-2),
                TransactionId = "XYZ789"
            },

            // Örnek 3
             new Payment
             {
                 Id = 3,
                 PaymentMethod = "Havale",
                 Amount = 200.00m,
                 Date = DateTime.Now.AddDays(-5),
                 TransactionId = "DEF456"
             },

            // Örnek 4
             new Payment
             {
                 Id = 4,
                 PaymentMethod = "Kripto Para",
                 Amount = 75.25m,
                 Date = DateTime.Now.AddDays(-1),
                 TransactionId = "GHI789"
             },

            // Örnek 5
             new Payment
             {
                 Id = 5,
                 PaymentMethod = "Çek",
                 Amount = 120.90m,
                 Date = DateTime.Now.AddDays(-3),
                 TransactionId = "JKL012"
             },
                new Payment
                {
                    Id = 6,
                    PaymentMethod = "Banka Kartı",
                    Amount = 85.60m,
                    Date = DateTime.Now.AddDays(-4),
                    TransactionId = "MNO345"
                },

            // Örnek 7
          new Payment
          {
              Id = 7,
              PaymentMethod = "EFT",
              Amount = 150.25m,
              Date = DateTime.Now.AddDays(-6),
              TransactionId = "PQR678"
          },

            // Örnek 8
             new Payment
             {
                 Id = 8,
                 PaymentMethod = "Sanal Cüzdan",
                 Amount = 60.30m,
                 Date = DateTime.Now.AddDays(-7),
                 TransactionId = "STU901"
             },

            // Örnek 9
            new Payment
            {
                Id = 9,
                PaymentMethod = "Mobil Ödeme",
                Amount = 40.15m,
                Date = DateTime.Now.AddDays(-8),
                TransactionId = "VWX234"
            },

            // Örnek 10
            new Payment
            {
                Id = 10,
                PaymentMethod = "Fatura Ödeme",
                Amount = 110.75m,
                Date = DateTime.Now.AddDays(-9),
                TransactionId = "YZA567"
            });
        }
    }
}

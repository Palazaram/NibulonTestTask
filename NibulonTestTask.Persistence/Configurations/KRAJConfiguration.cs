using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NibulonTestTask.Core.Models;


namespace NibulonTestTask.Persistence.Configurations
{
    public class KRAJConfiguration : IEntityTypeConfiguration<KRAJ>
    {
        public void Configure(EntityTypeBuilder<KRAJ> builder)
        {
            builder.HasKey(k => k.KRAJ_ID);

            builder.Property(k => k.NRAJ).HasMaxLength(200).IsRequired();

            builder.HasData(
                new KRAJ { KRAJ_ID = 1, NRAJ = "Фастівський" },
                new KRAJ { KRAJ_ID = 2, NRAJ = "Білоцерківський" },
                new KRAJ { KRAJ_ID = 3, NRAJ = "Полтавський" },
                new KRAJ { KRAJ_ID = 4, NRAJ = "Уманський" },
                new KRAJ { KRAJ_ID = 5, NRAJ = "Кам'янець-Подільський" },
                new KRAJ { KRAJ_ID = 6, NRAJ = "Драбівський" },
                new KRAJ { KRAJ_ID = 7, NRAJ = "Дерагчівський" },
                new KRAJ { KRAJ_ID = 8, NRAJ = "Валківський" },
                new KRAJ { KRAJ_ID = 9, NRAJ = "Кагарлицький" }
            );
        }
    }
}

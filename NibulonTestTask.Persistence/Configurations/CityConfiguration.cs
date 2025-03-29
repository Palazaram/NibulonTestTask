using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NibulonTestTask.Core.Models;


namespace NibulonTestTask.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.CITY_KOD);

            builder.Property(c => c.CITY_KOD).HasMaxLength(20).IsRequired();
            builder.Property(c => c.CITY).HasMaxLength(50).IsRequired();
            builder.Property(c => c.KRAJ_KOD).IsRequired(false);
            builder.Property(c => c.OBL_KOD).IsRequired(false);

            builder.HasOne(c => c.Kraj).WithMany(k => k.Cities).HasForeignKey(c => c.KRAJ_KOD);
            builder.HasOne(c => c.Obl).WithMany(o => o.Cities).HasForeignKey(c => c.OBL_KOD);

            builder.HasData(
                new City { CITY_KOD = "00001", CITY = "с. Кислівка", KRAJ_KOD = 2, OBL_KOD = 1101 },
                new City { CITY_KOD = "00002", CITY = "с. Першотравневе", KRAJ_KOD = null, OBL_KOD = null },
                new City { CITY_KOD = "00003", CITY = "с. Ягідне", KRAJ_KOD = null, OBL_KOD = 1103 },
                new City { CITY_KOD = "00004", CITY = "с. Білозірка", KRAJ_KOD = null, OBL_KOD = null },
                new City { CITY_KOD = "00005", CITY = "с. Матроска", KRAJ_KOD = null, OBL_KOD = null },
                new City { CITY_KOD = "00006", CITY = "с. Кучерівка", KRAJ_KOD = null, OBL_KOD = 1104 },
                new City { CITY_KOD = "00007", CITY = "с. Проказине", KRAJ_KOD = null, OBL_KOD = null },
                new City { CITY_KOD = "00008", CITY = "с. Івахни", KRAJ_KOD = 4, OBL_KOD = 1105 },
                new City { CITY_KOD = "00009", CITY = "с. Горобіївка", KRAJ_KOD = 1, OBL_KOD = 1101 },
                new City { CITY_KOD = "00010", CITY = "с. Паляничинці", KRAJ_KOD = 2, OBL_KOD = null },
                new City { CITY_KOD = "00011", CITY = "м. Полтава", KRAJ_KOD = 3, OBL_KOD = null } 
            );
        }
    }
}

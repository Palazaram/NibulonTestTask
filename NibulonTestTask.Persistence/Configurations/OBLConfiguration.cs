using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NibulonTestTask.Core.Models;


namespace NibulonTestTask.Persistence.Configurations
{
    public class OBLConfiguration : IEntityTypeConfiguration<OBL>
    {
        public void Configure(EntityTypeBuilder<OBL> builder)
        {
            builder.HasKey(o => o.KOBL);

            builder.Property(o => o.KOBL).ValueGeneratedNever();
            builder.Property(o => o.NOBL).HasMaxLength(200).IsRequired();

            builder.HasData(
                new OBL { KOBL = 1101, NOBL = "Київська" },
                new OBL { KOBL = 1103, NOBL = "Чернігівська" },
                new OBL { KOBL = 1104, NOBL = "Сумська" },
                new OBL { KOBL = 1105, NOBL = "Черкаська" },
                new OBL { KOBL = 1107, NOBL = "Полтавська" },
                new OBL { KOBL = 1108, NOBL = "Миколаївська" },
                new OBL { KOBL = 1110, NOBL = "Кіровоградська" }
            );
        }
    }
}

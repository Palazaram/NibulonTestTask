using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NibulonTestTask.Core.Models;


namespace NibulonTestTask.Persistence.Configurations
{
    public class AUPConfiguration : IEntityTypeConfiguration<AUP>
    {
        public void Configure(EntityTypeBuilder<AUP> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.INDEX_A).HasMaxLength(6).IsRequired();

            builder.Property(a => a.CITY_KOD).IsRequired(false).HasMaxLength(20);
            builder.Property(a => a.OBL_KOD).IsRequired(false);
            builder.Property(a => a.RAJ_KOD).IsRequired(false);

            builder.HasOne(a => a.City).WithMany(c => c.AUPs).HasForeignKey(a => a.CITY_KOD);
                //.OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.Obl).WithMany(o => o.AUPs).HasForeignKey(a => a.OBL_KOD);
                //.OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.Kraj).WithMany(k => k.AUPs).HasForeignKey(a => a.RAJ_KOD);
                //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}

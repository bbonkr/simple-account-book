
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Configurations
{
    public class AmountTypeConfiguration : IEntityTypeConfiguration<Amount>
    {
        public void Configure(EntityTypeBuilder<Amount> builder)
        {
            builder.ConfigureBase();

            builder.Property(x => x.SupplyPrice)
                .IsRequired()
                .HasColumnType("decimal(15, 2)")
                .HasDefaultValue(0)
                .HasComment("공급가액");

            builder.Property(x => x.Tax)
                .IsRequired()
                .HasColumnType("decimal(15, 2)")
                .HasDefaultValue(0)
                .HasComment("세액");

            builder.ToTable(nameof(Amount));
        }
    }
}

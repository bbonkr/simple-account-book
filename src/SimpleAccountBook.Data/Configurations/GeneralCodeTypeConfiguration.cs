
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Configurations
{
    public class GeneralCodeTypeConfiguration : IEntityTypeConfiguration<GeneralCode>
    {
        public void Configure(EntityTypeBuilder<GeneralCode> builder)
        {
            builder.ConfigureBase();

            builder.Property(x => x.ParentId)
                .HasColumnType("char(36)")
                .IsRequired(false)
                .HasComment("상위코드 식별자");

            builder.Property(x => x.Code)
                .HasMaxLength(100)
                .IsRequired(false)
                .HasComment("코드");

            builder.Property(x => x.Text)
                .HasMaxLength(300)
                .IsRequired()
                .HasComment("출력");

            builder.Property(x => x.Ordinal)
                .IsRequired()
                .HasDefaultValue(1)
                .HasComment("출력순서");

            builder.HasOne(x => x.Parent)
                .WithMany(x => x.SubCodes)
                .HasForeignKey(x => x.ParentId);

            // If needs
            //builder.HasIndex(x => x.ParentId)
            //    .HasFilter("parentId is not null");

            builder.ToTable(nameof(GeneralCode));
        }
    }
}

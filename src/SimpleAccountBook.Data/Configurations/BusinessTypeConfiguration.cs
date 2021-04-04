
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Configurations
{
    public class BusinessTypeConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.ConfigureBase();

            builder.Property(x => x.Name)
                .HasMaxLength(300)
                .IsRequired()
                .HasComment("상호");

            builder.Property(x => x.RegistrationNumber)
                .HasMaxLength(30)
                .IsRequired()
                .HasComment("사업자등록번호, 주민등록번호");

            builder.Property(x => x.AddressId)
                .HasColumnType("char(36)")
                .IsRequired(false)
                .HasComment("주소");

            builder.Property(x => x.BusinessItem)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasComment("업종");

            builder.Property(x => x.BusinessItemCode)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasComment("업종코드");

            builder.Property(x => x.TypeOfIncomeCode)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasComment("소득종류코드");

            builder.Property(x => x.UserId)
                .HasColumnType("char(36)")
                .IsRequired()
                .HasComment("사용자 식별자");

            builder.HasOne(x => x.Address)
                .WithOne()
                .HasForeignKey<Business>(x => x.AddressId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Businesses)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(nameof(Business));
        }
    }
}

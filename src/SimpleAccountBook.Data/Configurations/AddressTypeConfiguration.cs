
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Configurations
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ConfigureBase();

            builder.Property(x => x.Zipcode)
                .HasMaxLength(5)
                .IsRequired()
                .HasComment("우편번호");

            builder.Property(x => x.State)
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("도, 시");

            builder.Property(x => x.City)
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("시, 구");

            builder.Property(x => x.StreetAddress1)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasComment("세부주소1");

            builder.Property(x => x.StreetAddress2)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasComment("세부주소2");

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(30)
                .IsRequired(false)
                .HasComment("전화번호");

            builder.ToTable(nameof(Address));
        }
    }
}

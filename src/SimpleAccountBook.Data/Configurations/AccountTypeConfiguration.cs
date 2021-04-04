
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Configurations
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ConfigureBase();

            builder.Property(x => x.Name)
                .HasMaxLength(300)
                .IsRequired()
                .HasComment("상호, 법인명");

            builder.Property(x => x.RegistrationNumber)
                .HasMaxLength(30)
                .IsRequired(false)
                .HasComment("사업자등록번호, 법인등록번호");

            builder.Property(x => x.AddressId)
                .IsRequired(false)
                .HasComment("주소 식별자");

            builder.HasOne(x => x.Address)
                .WithOne()
                .HasForeignKey<Account>(x => x.AddressId);

            builder.ToTable(nameof(Account));
        }
    }
}

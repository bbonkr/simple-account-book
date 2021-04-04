
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Configurations
{
    public class StockTypeConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ConfigureBase();

            builder.Property(x => x.Year)
                .IsRequired()
                .HasComment("귀속년도");

            builder.Property(x => x.ProductBeginningOfYear)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("decimal(15, 2)")
                .HasComment("기초상품재고액");

            builder.Property(x => x.ProductEndYear)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("decimal(15, 2)")
                .HasComment("기말상품재고액");

            builder.Property(x => x.MaterialBeginningOfYear)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("decimal(15, 2)")
                .HasComment("기초재료재고액");

            builder.Property(x => x.MaterialEndYear)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("decimal(15, 2)")
                .HasComment("기말재료재고액");

            builder.Property(x => x.BusinessId)
                .IsRequired()
                .HasColumnType("char(36)")
                .HasComment("사업장 식별자");

            builder.HasOne(x => x.Business)
                .WithMany(x => x.Stocks)
                .HasForeignKey(x => x.BusinessId);

            builder.ToTable(nameof(Stock));
        }
    }
}

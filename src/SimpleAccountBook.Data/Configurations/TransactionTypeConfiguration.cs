
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Configurations
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ConfigureBase();

            builder.Property(x => x.Date)
                .HasColumnType("date")
                .IsRequired()
                .HasComment("일자");

            builder.Property(x => x.TransactionTypeId)
                .IsRequired()
                .HasColumnType("char(36)")
                .HasComment("거래구분 (수입, 비용, 고정자산)");

            builder.Property(x => x.TransactionDetailsId)
                .IsRequired()
                .HasColumnType("char(36)")
                .HasComment("거래내용");

            builder.Property(x => x.TransactionDetailsNote)
                .HasMaxLength(4000)
                .HasComment("거래내용 기록");

            builder.Property(x => x.AccountId)
                .HasColumnType("char(36)")
                .IsRequired()
                .HasComment("거래처 식별자");

            builder.Property(x => x.AmountId)
                .IsRequired()
                .HasColumnType("char(36)")
                .HasComment("금액 식별자");

            builder.Property(x => x.RemarkId)
                .IsRequired(false)
                .HasColumnType("char(36)")
                .HasComment("비고 식별자");

            builder.Property(x => x.RemarkNote)
                .HasMaxLength(4000)
                .HasComment("비고 기록");

            builder.Property(x => x.BusinessId)
                .HasColumnType("char(36)")
                .IsRequired()
                .HasComment("사업장 식별자");

            builder.HasOne(x => x.TransactionType)
                .WithMany()
                .HasForeignKey(x => x.TransactionTypeId);

            builder.HasOne(x => x.TransactionDetails)
                .WithMany()
                .HasForeignKey(x => x.TransactionDetailsId);

            builder.HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.AccountId);

            builder.HasOne(x => x.Amount)
                .WithOne()
                .HasForeignKey<Transaction>(x => x.AmountId);

            builder.HasOne(x => x.Remark)
                .WithMany()
                .HasForeignKey(x => x.RemarkId);

            builder.HasOne(x => x.Business)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.BusinessId);

            builder.ToTable(nameof(Transaction));
        }
    }
}

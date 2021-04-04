using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Configurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ConfigureBase();

            builder.Property(x => x.Email)
                .HasMaxLength(300)
                .IsRequired()
                .HasComment("전자우편주소, 로그인에 사용");

            builder
                .HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Password)
                .HasMaxLength(1000)
                .IsRequired()
                .HasComment("비밀번호, 해시됨");

            builder.Property(x => x.DisplayName)
                .HasMaxLength(300)
                .IsRequired()
                .HasComment("출력이름");

            builder.ToTable(nameof(User));
        }
    }
}

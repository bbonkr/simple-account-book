using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Configurations
{
    public static class EntityTypeBuilderExtension
    {
        public static EntityTypeBuilder<TEntity> ConfigureBase<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : EntityBase
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("char(36)")
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasComment("식별자");

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTimeOffset.UtcNow);

            builder.Property(x => x.UpdatedAt)
                .IsRequired(false);

            builder.Property(x => x.DeletedAt)
                .IsRequired(false);

            return builder;
        } 
    }
}

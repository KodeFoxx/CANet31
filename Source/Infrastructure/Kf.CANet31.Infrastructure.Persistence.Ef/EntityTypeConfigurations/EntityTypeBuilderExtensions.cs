﻿using Kf.CANet31.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kf.CANet31.Infrastructure.Persistence.Ef.EntityTypeConfigurations
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureId<TEntity>(
            this EntityTypeBuilder<TEntity> entityTypeBuilder,
            string idColumenName = "id"
        )
            where TEntity : Entity
        {
            entityTypeBuilder
                .HasKey(e => e.Id);
            entityTypeBuilder
                .Property(e => e.Id)
                .UseIdentityColumn(1, 1)
                .HasColumnName(idColumenName)
                .HasColumnType(SqlServerColumnTypes.Int64_BIGINT);
        }
    }
}

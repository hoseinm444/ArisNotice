namespace ArisNotices.Infra.Data.Sql.Configs;
public abstract class EntityBaseConfig<TEntity, TId> : IEntityTypeConfiguration<TEntity>
    where TEntity : EntityBase<TId>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(TId) == typeof(Guid))
            builder.Property(p => p.Id)
                .HasDefaultValueSql("newsequentialid()");

        builder.Property(p => p.CreateDate)
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        builder.Property(p => p.UpdateDate)
            .IsRequired()
            .HasDefaultValueSql("getdate()");
    }
}

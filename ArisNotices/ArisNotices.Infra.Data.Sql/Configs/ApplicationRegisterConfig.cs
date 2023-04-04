
namespace ArisNotices.Infra.Data.Sql.Configs;

public class ApplicationRegisterConfig : EntityBaseConfig<ApplicationRegister<Service>, Guid>
{
    
    public override void Configure(EntityTypeBuilder<ApplicationRegister<Service>> builder)
    {
        builder.HasQueryFilter(c => c.IsDeleted == false);

        builder.Property(p => p.ApplicationName)
            .IsRequired();

        builder
       .HasOne(a => a.Service).WithOne(b => b.ApplicationRegister)
       .HasForeignKey<ApplicationRegister<Service>>(b=>b.ServiceId).IsRequired();

        

        builder.Ignore(p => p.DomainEvents);
        builder.Ignore(p => p.Notice);
        builder.Ignore(p => p.Service);
        base.Configure(builder);
    }
}


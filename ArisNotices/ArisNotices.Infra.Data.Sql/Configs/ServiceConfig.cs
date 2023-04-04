
namespace ArisNotices.Infra.Data.Sql.Configs;

public class ServiceConfig : EntityBaseConfig<Service, Guid> 
{
    public override void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasQueryFilter(c => c.IsDeleted == false);

        builder.Property(p => p.ServiceName)
            .IsRequired();
       
        builder.Ignore(p => p.DomainEvents);
        builder.Ignore(p => p.ApplicationRegister);

        base.Configure(builder);
    }

}



using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArisNotices.Infra.Data.Sql.Configs;
public class NoticeConfig : EntityBaseConfig<Notice<Service>, Guid>
{

    public override void Configure(EntityTypeBuilder<Notice<Service>> builder)
    {
        builder.HasQueryFilter(c => c.IsDeleted == false);

        builder.Property(p => p.Topic)
            .IsRequired();
        builder.Property(p => p.Title)
            .IsRequired();

        builder.Property(p => p.SendResult)
            .IsRequired();
        builder.Property(p => p.Sender)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(p => p.Description).IsRequired(); 

        builder.Property(p => p.Header)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.ServiceType)
            .HasMaxLength(12)
            .IsRequired();

        builder.Property(p => p.Recipient)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(p => p.DeliverySchedule)
            .HasMaxLength(400)
            .IsRequired();

        //builder/*.Property(x => x.NoticePriorityId).IsRequired()*/
        //     .HasOne(x => x.NoticeType).WithOne(x=>x.Notice)
        //    .HasForeignKey<Notice<Service>>(x => x.NoticePriorityId);


        builder
            .Property(e => e.NoticePriorityId)
            .HasConversion<int>();



        builder
       .HasOne(a => a.ApplicationRegister).WithOne(b => b.Notice)
       .HasForeignKey<Notice<Service>>(b => b.ApplicationRegisterId).IsRequired();

        //builder
        //  .OwnsOne(o => o.DeliverySchedule, a =>
        //  {
        //      a.WithOwner();

        //      a.Property(a => a.StartTime)
        //        .HasMaxLength(18)
        //        .IsRequired();

        //      a.Property(a => a.EndTime)
        //          .HasMaxLength(18)
        //          .IsRequired();

        //      a.Property(a => a.Days)
        //          .HasMaxLength(18)
        //       .IsRequired();


        //      a.Property(a => a.Hours)
        //          .HasMaxLength(18)
        //          .IsRequired();

        //  });
        //builder.Navigation(x => x.DeliverySchedule).IsRequired();

        //builder.Property(user => user.Addresses)
        //   .HasConversion(
        //   a => (string)JsonConvert.SerializeObject(a),
        //   a => JsonConvert.DeserializeObject<List<Address>>(a));


        //builder
        // .OwnsOne(o => o.Recipient, a =>
        // {
        //     a.WithOwner();

        //     a.Property(a => a.PhoneNumber1)
        //       .HasMaxLength(11)
        //       .IsRequired();

        //     a.Property(a => a.PhoneNumber2)
        //         .HasMaxLength(11)
        //         .IsRequired();

        //     a.Property(a => a.EmailAddress)
        //         .HasMaxLength(60)
        //         .IsRequired();

        // });
        //builder.Navigation(x => x.Recipient).IsRequired();

        ///////////////////////////////////////////////////////////
        //var converter = new ValueConverter<NoticePriority, int>(
        //               v => v.Id,
        //               v => Enumeration.FromValue<NoticePriority>(v));
        //builder.Property(b => b.NoticeType).HasConversion(converter).IsRequired();




        builder.Ignore(p => p.DomainEvents);
        builder.Ignore(p => p.ApplicationRegister);
        //builder.Ignore(p => p.JsonNoticeSerialized);
        //builder.Ignore(p => p.DeliveryScheduleJson);
        //builder.Ignore(p => p.RecipientJson);


        base.Configure(builder);
    }

}


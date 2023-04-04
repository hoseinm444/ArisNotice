
//using ArisNotices.Infra;

//namespace ArisNotices.Infra.Data.Sql.Configs;
//public class NoticePriorityConfig : IEntityTypeConfiguration<NoticePriority>
//{
//    public void Configure(EntityTypeBuilder<NoticePriority> builder)
//    {

//        // builder.ToTable("NoticeStatus", ArisNoticesContext.DEFAULT_SCHEMA);

//        //builder.HasKey(o => o.NoticeId);

//       // builder.OwnEnumeration(x => x.);

//        //builder.HasKey(x => x.Id);
//        builder.Property(x => x.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();
//        builder.Property(x => x.Name).IsRequired();

//    }

//}


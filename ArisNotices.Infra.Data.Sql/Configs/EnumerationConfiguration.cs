
//using System.Linq.Expressions;

//namespace ArisNotices.Infra;
//public static class EnumerationConfiguration
//{
//    public static void OwnEnumeration<TEntity, TEnum>(this EntityTypeBuilder<TEntity> builder,
//        Expression<Func<TEntity, TEnum>> property)
//        where TEntity : class
//        where TEnum : Enumeration
//    {
//        builder
//            .Property(property)
//            .HasConversion(x => x.Id, x => Enumeration.FromValue<TEnum>(x));
//        //.GetAll<TEnum>()
//        //.HasConversion(x => x.Id, x => Enumeration.FromId<TEnum>(x));
//    }

//}


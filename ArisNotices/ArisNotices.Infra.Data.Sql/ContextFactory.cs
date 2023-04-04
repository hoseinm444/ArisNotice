namespace ArisNotices.Infra.Data.Sql;

public static class ContextFactory
{
    public static ArisNoticesContext GetSqlContext()
    {
        var builder = new DbContextOptionsBuilder<ArisNoticesContext>();

        builder.UseSqlServer(@"Server=DESKTOP-01LMUME\SQL2019; Initial Catalog=ArisNotices;Integrated Security=True;");
        return new ArisNoticesContext(builder.Options);
    }
    //builder.UseSqlServer(@"Server=DESKTOP-01LMUME\SQL2019; Initial Catalog=ArisNotices;Integrated Security=True;");

    //public static ArisNoticesContext GetSqlContext(OrganizationBase accessToOrganization)
    //{
    //    var builder = new DbContextOptionsBuilder<ArisNoticesContext>();

    //    builder.UseSqlServer("Server=.\\SQL2019;Initial Catalog=ArisNotices;User Id=sa;Password=Aris3797;");
    //    return new ArisNoticesContext(builder.Options, accessToOrganization);
    //}

    public static ArisNoticesContext GetSqlContext(IMediator mediator)
    {
        var builder = new DbContextOptionsBuilder<ArisNoticesContext>();

        builder.UseSqlServer("Server=.\\SQL2019;Initial Catalog=ArisNotices;User Id=sa;Password=Aris3797");
        return new ArisNoticesContext(builder.Options, mediator);
    }

}


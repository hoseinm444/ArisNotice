﻿
using Microsoft.EntityFrameworkCore.Design;

namespace ArisNotices.Infra.Data.Sql;
public class ArisNoticesContextDesignFactory : IDesignTimeDbContextFactory<ArisNoticesContext>
{
    public ArisNoticesContext CreateDbContext(string[] args) => ContextFactory.GetSqlContext();

    //class NoMediator : IMediator
    //{
    //    public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IAsyncEnumerable<object> CreateStream(object request, CancellationToken cancellationToken = default)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification
    //    {
    //        return Task.CompletedTask;
    //    }

    //    public Task Publish(object notification, CancellationToken cancellationToken = default)
    //    {
    //        return Task.CompletedTask;
    //    }

    //    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        return Task.FromResult<TResponse>(default(TResponse));
    //    }

    //    public Task<object> Send(object request, CancellationToken cancellationToken = default)
    //    {
    //        return Task.FromResult(default(object));
    //    }
    //}
}


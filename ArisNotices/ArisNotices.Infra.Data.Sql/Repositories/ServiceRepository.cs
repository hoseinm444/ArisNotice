
using ArisNotices.Domain.AggregatesModel.NoticeService;

using Microsoft.EntityFrameworkCore;

namespace ArisNotices.Infra.Data.Sql.Repositories;
public class ServiceRepository : IServiceRepository/*<T> where T:Service<T> ,IAggregateRoot*/
{
    private readonly ArisNoticesContext context;

    public ServiceRepository(ArisNoticesContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IUnitOfWork UnitOfWork => context;

    public async Task<Service> AddAsync(IService/*<T>*/ service)
    {
        using (var transaction = await context.BeginTransactionAsync())
        {
            Service serviceEntity = new Service(service);

            serviceEntity.Create();
            var returnService = context.Services.Add(serviceEntity).Entity;
            if (await context.CommitTransactionAsync(transaction) > 0)
                return returnService;
            else
                return null;
        }
    }

    public async Task<bool> DeleteAsync(IService/*<T>*/ service)
    {
        if (service is not null)
        {
            Service? entity = await context.Services.FirstOrDefaultAsync<Service>(find => find.Id == service.Id);
            if (entity is not null)
                using (var transaction = await context.BeginTransactionAsync())
                {
                    try
                    {
                        entity.Delete();
                        if (await context.CommitTransactionAsync(transaction) > 0)
                            return true;
                        else
                            return false;
                    }
                    catch
                    {
                        context.RollbackTransaction();
                        throw;
                    }
                }
            else
                return false;
        }
        else
            return false;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var service = await context.Services.FirstOrDefaultAsync<Service>(find => find.Id == id);
        return await DeleteAsync(service);
    }

    public async Task<IEnumerable<Service>> FindAllAsync()
    {
        var service = await context.Services.Where(n => n.IsDeleted == false)
             .ToListAsync<Service>();
        return service;
    }

    public async Task<Service> FindByIdAsync(Guid id)
    {
        var service = await context.Services.Where(a => a.Id == id)
            .FirstOrDefaultAsync();
        return service;
    }

    public async Task<Service> FindByNameServiceAsync(string serviceName)
    {
        var service = await context.Services.Where(a => a.ServiceName == serviceName)
            .FirstOrDefaultAsync();
        return service ;
    }

    //public async Task<Service> FindByServiceConfigAsync(Service serviceconfig)
    //{
    //    var service = await context.Services.Where(a => a.ServiceConfige == serviceconfig)
    //        .FirstOrDefaultAsync();
    //    return service;
    //}

    public async Task<Service> UpdateAsync(IService service)
    {
        if (service is not null)
        {
            Service? entity = await context.Services.AsNoTracking()
                .FirstOrDefaultAsync<Service>(find => find.Id == service.Id);
            if (entity is not null)
                using (var transaction = await context.BeginTransactionAsync())
                {
                    try
                    {
                        entity.Update(service);
                        context.Update(entity);
                        if (await context.CommitTransactionAsync(transaction) > 0)
                            return entity;
                        else
                            return null;
                    }
                    catch
                    {
                        context.RollbackTransaction();
                        throw;
                    }
                }
            else
                return null;
        }
        else
            return null;
    }
}


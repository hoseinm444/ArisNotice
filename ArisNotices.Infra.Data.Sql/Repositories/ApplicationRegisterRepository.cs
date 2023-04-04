
using Microsoft.EntityFrameworkCore;

namespace ArisNotices.Infra.Data.Sql.Repositories;
public class ApplicationRegisterRepository : IApplicationRegisterRepository
{
    private readonly ArisNoticesContext context;

    public ApplicationRegisterRepository(ArisNoticesContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IUnitOfWork UnitOfWork => context;
    public async Task<IEnumerable<ApplicationRegister<Service>>> FindAllAsync()
    {
        var apps = await context.Applications.ToListAsync<ApplicationRegister<Service>>();
        return apps;
    }
    public async Task<ApplicationRegister<Service>> AddAsync(IApplicationRegister application)
    {
        using (var transaction = await context.BeginTransactionAsync())
        {
           ApplicationRegister<Service> appRegister = new ApplicationRegister<Service>(application);
            
            appRegister.Create();
            var returnApp = context.Applications.Add(appRegister).Entity;
            if (await context.CommitTransactionAsync(transaction) > 0)
                return returnApp;
            else
                return null;
        }
    }

    public async Task<bool> DeleteAsync(IApplicationRegister application)
    {
        if (application is not null)
        {
            ApplicationRegister<Service>? entity = await context.Applications.FirstOrDefaultAsync<ApplicationRegister<Service>>(find => find.Id == application.Id);
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
        var app = await context.Applications.FirstOrDefaultAsync<ApplicationRegister<Service>>(find => find.Id == id);
        return await DeleteAsync(app);
    }

    public async Task<ApplicationRegister<Service>> FindByApplicationNameAsync(string AppName)
    {
        var app = await context.Applications.Where(a => a.ApplicationName == AppName)
            .FirstOrDefaultAsync();
        return app;
    }

    public async Task<ApplicationRegister<Service>> FindByIdAsync(Guid id)
    {
        var app = await context.Applications.Where(a => a.Id == id)
            .FirstOrDefaultAsync();
        return app;
    }

    //public async Task<ApplicationRegister<Service>> FindByServicegAsync(Service serviceName)
    //{
    //    var app = await context.Services.Where(a => a.ServiceId == serviceName)
    //        .FirstOrDefaultAsync();
    //    return app;
    //}

    public async Task<ApplicationRegister<Service>> UpdateAsync(IApplicationRegister application)
    {
        if (application is not null)
        {
            ApplicationRegister<Service>? entity = await context.Applications.AsNoTracking()
                .FirstOrDefaultAsync<ApplicationRegister<Service>>(find => find.Id == application.Id);
            if (entity is not null)
                using (var transaction = await context.BeginTransactionAsync())
                {
                    try
                    {
                        entity.Update(application);
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


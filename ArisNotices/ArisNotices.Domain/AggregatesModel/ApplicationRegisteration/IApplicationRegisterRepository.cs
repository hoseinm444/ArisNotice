
namespace ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;

public interface IApplicationRegisterRepository : IRepository<ApplicationRegister<Service>> 
{
    Task<IEnumerable<ApplicationRegister<Service>>> FindAllAsync();
    Task<ApplicationRegister<Service>> AddAsync(IApplicationRegister application);
    Task<ApplicationRegister<Service>> UpdateAsync(IApplicationRegister application);

    Task<bool> DeleteAsync(IApplicationRegister application);
    Task<bool> DeleteByIdAsync(Guid id);

    //read 
    Task<ApplicationRegister<Service>> FindByApplicationNameAsync(string AppName);
    Task<ApplicationRegister<Service>> FindByIdAsync(Guid id);
  //  Task<ApplicationRegister<T>> FindByServicegAsync<T>(Service<T> serviceName) where T:class,new();
}
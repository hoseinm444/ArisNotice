
namespace ArisNotices.Domain.AggregatesModel.NoticeService;

public interface IServiceRepository: IRepository<Service> , IAggregateRoot
{
    Task<IEnumerable<Service>> FindAllAsync();
    Task<Service> AddAsync(IService service);
    Task<Service> UpdateAsync(IService service);

    Task<bool> DeleteAsync(IService service);
    Task<bool> DeleteByIdAsync(Guid id);

    //read 
    Task<Service> FindByNameServiceAsync(string serviceName);
    Task<Service> FindByIdAsync(Guid id);
    
}
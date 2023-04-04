

using ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;
using ArisNotices.Domain.AggregatesModel.Notice;
using GeneralInfo.SeedWork.Domain;

namespace ArisNotices.Domain.AggregatesModel.NoticeService;

public class Service : EntityBase<Guid>, IAggregateRoot, IService
{
    public Service()
    {

    }
    public Service(IService service) : base(service.Id)
    {
        ServiceName = service.ServiceName ?? throw new ArgumentNullException(nameof(service.ServiceName));

    }
    public Service(string Servicename)
    {
        ServiceName = Servicename ?? throw new ArgumentNullException(nameof(Servicename));
    }
    public string ServiceName { get; private set; }
    public ApplicationRegister<Service>? ApplicationRegister { get; private set; }


    public bool Update(IService service)
    {
        if (service is not null)
        {
            ServiceName = service.ServiceName;

            base.Update();
            return true;
        }
        else
            return false;
    }

}
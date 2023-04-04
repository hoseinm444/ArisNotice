
using ArisNotices.Domain.AggregatesModel.Notice;
using GeneralInfo.SeedWork.Domain;

namespace ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;
public class ApplicationRegister<Servise> : EntityBase<Guid>, IAggregateRoot, IApplicationRegister
{
    public ApplicationRegister()
    {

    }
    public ApplicationRegister(IApplicationRegister appRegister) : base(appRegister.Id)
    {
        ApplicationName = appRegister.ApplicationName ?? throw new ArgumentNullException(nameof(appRegister.ApplicationName));
        ServiceId = appRegister.ServiceId;
       
    }
    public ApplicationRegister(string AppName, Service serviceId)
    {
        ApplicationName = AppName ?? throw new ArgumentNullException(nameof(AppName));
        ServiceId = serviceId.Id;
    }
    public string ApplicationName { get; private set; }

    public Guid? ServiceId { get; private set; }
    public  Service? Service { get;private set; }

    
   
    public Notice<Service> Notice { get; private set; }

    public bool Update(IApplicationRegister appRegister)
    {
        if (appRegister is not null)
        {
            ApplicationName = appRegister.ApplicationName;
            ServiceId = appRegister.ServiceId;
            base.Update();
            return true;
        }
        else
            return false;
    }
}


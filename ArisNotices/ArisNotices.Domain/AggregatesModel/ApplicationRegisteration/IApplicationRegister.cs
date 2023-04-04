using ArisNotices.Domain.AggregatesModel.NoticeService;

namespace ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;
public interface IApplicationRegister
{
    [JsonIgnore]
    public Guid Id { get; }
    public string ApplicationName { get; }
    public Guid? ServiceId { get; } 
}



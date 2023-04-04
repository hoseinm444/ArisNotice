
namespace ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;
public class ApplicationRegisterDto : IApplicationRegister
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public string ApplicationName { get; set; }

    public Guid? ServiceId { get; set; }
}


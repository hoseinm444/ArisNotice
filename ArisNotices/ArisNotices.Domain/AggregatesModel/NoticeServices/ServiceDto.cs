

namespace ArisNotices.Domain.AggregatesModel.NoticeService;

public class ServiceDto : IService
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string ServiceName { get; set; }
}


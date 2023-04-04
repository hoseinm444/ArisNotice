namespace ArisNotices.Domain.AggregatesModel.NoticeService;
public  interface IService
{
    [JsonIgnore]
    public Guid Id { get; }
    public string ServiceName { get; }
    
}
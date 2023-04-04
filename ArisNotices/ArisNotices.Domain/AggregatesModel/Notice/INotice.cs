
using ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;
using ArisNotices.Domain.AggregatesModel.Notice.RecipientInfo;

namespace ArisNotices.Domain.AggregatesModel.Notice;

public interface INotice
{
   
    public Guid Id { get; }
    public string Header { get; }
    public string Title { get; }
    public string Description { get; }
    public int NoticePriorityId { get; }
    public string Topic { get; }
    public string Sender { get; }
    public string DeliverySchedule { get; }
    public string Recipient { get; }
    public Guid? ApplicationRegisterId { get; }
    public  String? ServiceType { get; }
    public  string SendResult { get; } 

}


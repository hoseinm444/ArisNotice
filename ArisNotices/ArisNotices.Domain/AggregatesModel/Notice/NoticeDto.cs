
using ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;
using System.Runtime.Serialization;

namespace ArisNotices.Domain.AggregatesModel.Notice;
public class NoticeDto : ISerializable, INotice
{
    //private readonly string _sendResult;//for readonly property
    //public NoticeDto()
    //{
    //    _sendResult = "not sended untill now";
    //}
    public Guid Id { get; set; }
    public string Header { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int NoticePriorityId { get; set; }
    public string Topic { get; set; }
    public string Sender { get; set; }
    public string DeliverySchedule { get; set; }
    public string Recipient { get; set; }
    public Guid? ApplicationRegisterId { get; set; }
    public string? ServiceType { get; set; }
    public string SendResult { get; set; }//for readonly property

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }
    public Notice<Service> ConvertToDocument()
    {
        return new Notice<Service>(this);
    }
}



using ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;
using System;

namespace ArisNotices.Domain.AggregatesModel.Notice;
public class Notice<T> : EntityBase<Guid>, IAggregateRoot, INotice
{
#pragma warning disable CS8618 // Required by Entity Framework
    public Notice()
    {

    }
    public Notice(INotice notice/*, IDeliverySchedule? deliverySchedule = null, IRecipient? recipient = null*/ ) : base(notice.Id)
    {
        Header = notice.Header ?? throw new ArgumentNullException(nameof(notice.Header));
        Title = notice.Title ?? throw new ArgumentNullException(nameof(notice.Title));
        Description = notice.Description ?? throw new ArgumentNullException(nameof(notice.Description));

        NoticePriorityId = SetNoPriorityStatus(notice.NoticePriorityId);
        NoticePriorityId = SetHighStatus(notice.NoticePriorityId);

        Topic = notice.Topic ?? throw new ArgumentNullException(nameof(notice.Topic));

        Sender = notice.Sender ?? throw new ArgumentNullException(nameof(notice.Sender));

        ServiceType = notice.ServiceType;
        ApplicationRegisterId = notice.ApplicationRegisterId;

        SendResult = ResultOfNotice(notice.SendResult);

        DeliverySchedule = notice.DeliverySchedule;
        Recipient = notice.Recipient;

    }
    public Notice(string header, string title, string description, int priority,
      string topic,
      string deliverySchedule,
      string sender,
      string recipients,
      string? serviceType,
       Guid? applicationId,
       string sendResult)
    {
        Header = header ?? throw new ArgumentNullException(nameof(header));
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Description = description ?? throw new ArgumentNullException(nameof(description));

        NoticePriorityId = SetNoPriorityStatus(priority);
        NoticePriorityId = SetHighStatus(priority);

        Topic = topic ?? throw new ArgumentNullException(nameof(topic));
        Sender = sender ?? throw new ArgumentNullException(nameof(sender));

        ServiceType = serviceType;
        ApplicationRegisterId = applicationId;

        SendResult = ResultOfNotice(sendResult);

        DeliverySchedule = deliverySchedule;
        Recipient = recipients;


    }

    public void SetApplicationId(Guid? id)
    {
        ApplicationRegisterId = id;
    }



    public string Header { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }



    public int NoticePriorityId { get; private set; }


    public string Topic { get; private set; }
    public string Sender { get; private set; }


    public string DeliverySchedule { get; private set; }
    //public string DeliveryScheduleJson { get; private set; }


    public string Recipient { get; private set; }
    //public string RecipientJson { get; private set; }



    //public Service? Service { get; private set; } 
    public string? ServiceType { get; private set; }


    public Guid? ApplicationRegisterId { get; private set; }
    public ApplicationRegister<Service>? ApplicationRegister { get; private set; }


   // public string JsonNoticeSerialized { get; private set; }

    public string SendResult { get; private set; }

    /// ////////////////////////////////////////////////////////////////////////////////////////

    public bool Update(INotice notice)
    {
        if (notice is not null)
        {
            Header = notice.Header;
            Title = notice.Title;
            Description = notice.Description;

            NoticePriorityId = SetNoPriorityStatus(notice.NoticePriorityId);
            NoticePriorityId = SetHighStatus(notice.NoticePriorityId);

            Topic = notice.Topic;


            //DeliveryScheduleForCronExpression(notice.DeliverySchedule);
            DeliverySchedule = notice.DeliverySchedule;
            Recipient = notice.Recipient;

            Sender = notice.Sender;


            ServiceType = notice.ServiceType;
            ApplicationRegisterId = notice.ApplicationRegisterId;


            SendResult = ResultOfNotice(notice.SendResult);

            base.Update();
            return true;
        }
        else
            return false;
    }

    ////Enums Set values
    ///
    public int SetNoPriorityStatus(int noticePriorityId)
    {
        if (noticePriorityId == NoticePriority.NoPriority.Id)
        {
            NoticePriorityId = NoticePriority.NoPriority.Id;
        }
        return NoticePriorityId;
    }
    public int SetHighStatus(int noticePriorityId)
    {
        if (noticePriorityId == NoticePriority.High.Id)
        {
            NoticePriorityId = NoticePriority.High.Id;
        }
        return NoticePriorityId;
    }

    public string ResultOfNotice(string result)
    {
        if (result is not null)
        {
            SendResult = result;
             return SendResult;
        }
        else
        {
          return "result is null";
        }

    }

    //public string DeliveryScheduleForCronExpression(string DeliverySchedule)
    //{
    //    JsonDocument document = JsonDocument.Parse(DeliverySchedule);
    //    JsonElement root = document.RootElement;

    //    JsonElement startPeriodicTime = root.GetProperty("startPeriodicTime");
    //    JsonElement endPeriodicTime = root.GetProperty("endPeriodicTime");

    //    JsonElement years = root.GetProperty("years");
    //    JsonElement daysOfWeek = root.GetProperty("daysOfWeek");
    //    JsonElement months = root.GetProperty("months");
    //    JsonElement daysOfMonth = root.GetProperty("daysOfMonth");
    //    JsonElement hours = root.GetProperty("hours");
    //    JsonElement minutes = root.GetProperty("minutes");
    //    JsonElement secondes = root.GetProperty("secondes");


    //    var cronExpression = $"{years} {daysOfWeek} {months} {daysOfMonth} " +
    //        $"{hours} {minutes} {secondes}".ToString();
    
    //    return cronExpression + $"{startPeriodicTime}"+ $"{endPeriodicTime}";
    //}

    //public string JsonNoticeSerializer(INotice notice)
    //{
    //    if (notice is not null)
    //    {
    //        var NoticeJson = JsonSerializer.Serialize(notice);
    //        return NoticeJson;
    //    }
    //    else
    //        throw new ArgumentNullException(nameof(notice));
    //}
    //var NoticeJson = JsonSerializer.Serialize(notice);
    //    return NoticeJson;
    //in post method we create an serializer that serialize the object of client entry and 
    //after and send it with post method to the another service .
    //or rise an event and event handler when client make an object of Notice
}

//////////////////////////////////

using ArisNotices.Domain.AggregatesModel.Notice;
using ArisNotices.Domain.AggregatesModel.Notice.RecipientInfo;

namespace ArisNotices.Domain;

public static class SerializerExtensions
{
    public static string DeliveryScheduleJson(this IDeliverySchedule delivery)
    {
        if (delivery is not null)
        {
            var deliveryScheduleJson = JsonSerializer.Serialize(delivery);
            return deliveryScheduleJson;
        }
        else
            throw new ArgumentNullException(nameof(delivery));

    }
    public static List<IRecipient> RecipientsList { get; private set; }

    public static string RecpientJson(this IRecipient recipient)
    {
        if (recipient is not null)
        {
            RecipientsList.Add(recipient);
            var recipientJson = JsonSerializer.Serialize(recipient);
            return recipientJson;
        }
        else
            throw new ArgumentNullException(nameof(recipient));
    }

   


    public static string JsonNoticeSerializer(this INotice notice)
    {
        if (notice is not null)
        {
            var NoticeJson = JsonSerializer.Serialize(notice);
            return NoticeJson;
        }
        else
            throw new ArgumentNullException(nameof(notice));
    }

    //public static string GetGenericTypeName(this Type type)
    //{
    //    var typeName = string.Empty;

    //    if (type.IsGenericType)
    //    {
    //        var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
    //        typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
    //    }
    //    else
    //    {
    //        typeName = type.Name;
    //    }

    //    return typeName;
    //}

    //public static string GetGenericTypeName(this object @object)
    //{
    //    return @object.GetType().GetGenericTypeName();
    //}
}


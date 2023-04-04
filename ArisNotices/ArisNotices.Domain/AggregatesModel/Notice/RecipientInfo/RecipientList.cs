
//using System.Collections;
//using System.Linq;

//namespace ArisNotices.Domain.AggregatesModel.Notice.RecipientInfo;
//public class RecipientList : IEnumerable<Recipient>
//{
//    private List<Recipient> _recipients { get; }

//    public RecipientList(IEnumerable<Recipient> recipients)
//    {
//        _recipients = recipients.ToList();
//    }

//    public RecipientList AddRecipient(IRecipient recipient)
//    {
//        List<Recipient> rec = _recipients.ToList();
//        rec.Add(new Recipient(recipient.PhoneNumber1, recipient.PhoneNumber2, recipient.EmailAddress));

//        return new RecipientList(rec);
//    }

//    public static explicit operator RecipientList(string recipientList)
//    {
//        List<Recipient> rec = recipientList.Split(';')
//            .Select(x => (Recipient)x)
//            .ToList();

//        return new RecipientList(rec);
//    }

//    public IEnumerator<Recipient> GetEnumerator()
//    {
//        return _recipients.GetEnumerator();
//    }

//    IEnumerator IEnumerable.GetEnumerator()
//    {
//        return GetEnumerator();
//    }

//    public static implicit operator string(RecipientList recipientList)
//    {
//        return string.Join(";", recipientList.Select(x => (string)x));
//    }
    
//}


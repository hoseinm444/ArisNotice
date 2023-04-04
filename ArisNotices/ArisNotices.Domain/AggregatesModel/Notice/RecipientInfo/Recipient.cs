
using System.ComponentModel.DataAnnotations;

namespace ArisNotices.Domain.AggregatesModel.Notice.RecipientInfo;

public class Recipient :  IRecipient
{

    public Recipient()
    {
       
    }
    public Recipient(string emailAddress)
    {
        EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
    }

  

    public Recipient(string phoneNumber1, string phoneNumber2, string emailAddress)
    {
        PhoneNumber1 = phoneNumber1 ?? throw new ArgumentNullException(nameof(phoneNumber1));
        PhoneNumber2 = phoneNumber2 ?? throw new ArgumentNullException(nameof(phoneNumber2));
        EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
    }
    public Recipient(IRecipient recipient)
    {
        PhoneNumber1 = recipient.PhoneNumber1 ?? throw new ArgumentNullException(nameof(recipient.PhoneNumber1));
        PhoneNumber2 = recipient.PhoneNumber2 ?? throw new ArgumentNullException(nameof(recipient.PhoneNumber2));
        EmailAddress = recipient.EmailAddress ?? throw new ArgumentNullException(nameof(recipient.EmailAddress));
    }

    

   // public List<Recipient> RecipientsList();
    //[JsonIgnore]

    public string PhoneNumber1 { get; private set; }
    public string PhoneNumber2 { get; private set; }

    [EmailAddress]
    public string EmailAddress { get; private set; }


    //public static explicit operator Recipient(string recipient)
    //{
    //    List<Recipient> recip = recipient.Split(';')
    //        .Select(x => (Recipient)x)
    //        .ToList();

    //    return new Recipient(recip);
    //}
}


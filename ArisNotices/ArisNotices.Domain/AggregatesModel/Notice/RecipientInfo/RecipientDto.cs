
using System.ComponentModel.DataAnnotations;

namespace ArisNotices.Domain.AggregatesModel.Notice.RecipientInfo;
public class RecipientDto : IRecipient
{
    public string PhoneNumber1 { get; set; }
    public string PhoneNumber2 { get; set; }
    [EmailAddress]
    public string EmailAddress { get; set; }
}


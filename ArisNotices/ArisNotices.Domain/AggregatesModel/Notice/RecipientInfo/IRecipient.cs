
namespace ArisNotices.Domain.AggregatesModel.Notice.RecipientInfo;

public interface IRecipient
{
    // public Guid Id { get; }
    public string PhoneNumber1 { get; }
    public string PhoneNumber2 { get; }
    public string EmailAddress { get; }
}


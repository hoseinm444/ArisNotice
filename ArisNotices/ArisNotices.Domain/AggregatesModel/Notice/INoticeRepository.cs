
using ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;
namespace ArisNotices.Domain.AggregatesModel.Notice;
public interface INoticeRepository: IRepository<Notice<Service>>
{
    Task<Notice<Service>> AddAsync(INotice notice);
    Task<Notice<Service>> UpdateAsync(INotice notice);

    Task<bool> DeleteAsync(INotice notice);
    Task<bool> DeleteByIdAsync(Guid id);

    //read 
    // Task<IEnumerable<Notice>> NoticeList();
    Task<Notice<Service>> FindByNoticeSenderAsync(string noticeSender, CancellationToken cancellationToken = default);
    Task<Notice<Service>> FindByNoticeTopicAsync(string noticeTopic, CancellationToken cancellationToken = default);
    Task<Notice<Service>> FindByNoticeHeaderAsync(string noticeHeader, CancellationToken cancellationToken = default);
    Task<Notice<Service>> FindByNoticeTitleAsync(string noticeTitle, CancellationToken cancellationToken = default);
    Task<Notice<Service>> FindByNoticeServiceNameAsync(string noticeServiceName, CancellationToken cancellationToken = default);
    Task<Notice<Service>> FindByNoticeApplicationNameAsync(IApplicationRegister application, CancellationToken cancellationToken = default);
    //Task<Notice<Service>> FindByNoticeDeliverySchedule(DeliverySchedule deliverySchedule, CancellationToken cancellationToken = default);
    //Task<Notice<Service>> FindByNoticeRecipient(Recipient recipient, CancellationToken cancellationToken = default);

    //Task<DeliverySchedule> FindDeliverySchedule(DeliverySchedule? deliverySchedule=null, DateTime? startTime = null, DateTime? EndTime = null
    //    , IList<DateTime>? Daus=null, IList<DateTime>? hours = null, CancellationToken cancellationToken = default);
    //Task<Recipient<Service>> FindRecipient(Recipient<Service>? recipient = null, string? phoneNumber1 = null
    //    , string? phoneNumber2 = null, string? email = null, CancellationToken cancellationToken = default);
    Task<IEnumerable<Notice<Service>>> FindAllAsync();
    Task<Notice<Service>> FindAsync(INotice document);
    Task<Notice<Service>> FindByIdAsync(Guid id);
    //  Task<Notice> FindByServicegAsync(Service serviceName);


}
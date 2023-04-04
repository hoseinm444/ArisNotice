
using ArisNotices.Domain.AggregatesModel.Notice.DeliveryScheduleService;
using ArisNotices.Domain.AggregatesModel.Notice.RecipientInfo;
using Microsoft.EntityFrameworkCore;

namespace ArisNotices.Infra.Data.Sql.Repositories;
public class NoticeRepository : INoticeRepository
{
    private readonly ArisNoticesContext context;

    public NoticeRepository(ArisNoticesContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IUnitOfWork UnitOfWork => context;

    public async Task<Notice<Service>> AddAsync(INotice notice)
    {
        using (var transaction = await context.BeginTransactionAsync())
        {
            Notice<Service> noticeEntity = new Notice<Service>(notice);

            noticeEntity.Create();
            var returnNotice = context.Notices.Add(noticeEntity).Entity;
            if (await context.CommitTransactionAsync(transaction) > 0)
                return returnNotice;
            else
                return null;
        }
    }

    

    public async Task<bool> DeleteAsync(INotice notice)
    {
        if (notice is not null)
        {
            Notice<Service>? entity = await context.Notices.SingleOrDefaultAsync<Notice<Service>>(find => find.Id == notice.Id);
            if (entity is not null)
                using (var transaction = await context.BeginTransactionAsync())
                {
                    try
                    {
                        entity.Delete();
                        if (await context.CommitTransactionAsync(transaction) > 0)
                            return true;
                        else
                            return false;
                    }
                    catch
                    {
                        context.RollbackTransaction();
                        throw;
                    }
                }
            else
                return false;
        }
        else
            return false;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var notice = await context.Notices.Where(n => n.Id ==id ).SingleOrDefaultAsync();
        
        return await DeleteAsync(notice);
         
    }
    public async Task<Notice<Service>> FindByIdAsync(Guid id)
    {
        var notice = await context.Notices.Where(a => a.Id == id)
            .FirstOrDefaultAsync();
        return notice;
    }
    public  async Task<Notice<Service>> FindByNoticeHeaderAsync(string noticeHeader)
    {
        var notice = await context.Notices.Where(a => a.Header == noticeHeader)
            .FirstOrDefaultAsync();
        return notice;
    }
    public async Task<Notice<Service>> FindByNoticeSenderAsync(string noticeSender)
    {
        var notice = await context.Notices.Where(a => a.Sender==noticeSender)
            .FirstOrDefaultAsync();
        return notice;
    }
    public async Task<Notice<Service>> FindByNoticeTitleAsync(string noticeTitle)
    {
        var notice = await context.Notices.Where(a => a.Title == noticeTitle)
             .FirstOrDefaultAsync();
        return notice;
    }
    public async Task<Notice<Service>> FindByNoticeTopicAsync(string noticeTopic)
    {
        var notice = await context.Notices.Where(a => a.Topic == noticeTopic)
             .FirstOrDefaultAsync();
        return notice;
    }
    public async Task<Notice<Service>> UpdateAsync(INotice notice)
    {
        if (notice is not null)
        {
            Notice<Service>? entity = await context.Notices.AsNoTracking()
                .FirstOrDefaultAsync<Notice<Service>>(find => find.Id == notice.Id);
            if (entity is not null)
                using (var transaction = await context.BeginTransactionAsync())
                {
                    try
                    {
                        entity.Update(notice);
                        context.Update(entity);
                        if (await context.CommitTransactionAsync(transaction) > 0)
                            return entity;
                        else
                            return null;
                    }
                    catch
                    {
                        context.RollbackTransaction();
                        throw;
                    }
                }
            else
                return null;
        }
        else
            return null;
    }



    public Task<Notice<Service>> FindByNoticeTopicAsync(string noticeTopic, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<Notice<Service>> FindByNoticeTitleAsync(string noticeTitle, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<Notice<Service>> FindByNoticeSenderAsync(string noticeSender, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<Notice<Service>> FindByNoticeServiceNameAsync(string noticeServiceName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<Notice<Service>> FindByNoticeHeaderAsync(string noticeHeader, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<Notice<Service>> FindByNoticeRecipient(Recipient recipient, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<Notice<Service>> FindByNoticeApplicationNameAsync(IApplicationRegister application, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<Notice<Service>> FindByNoticeDeliverySchedule(DeliverySchedule deliverySchedule, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<Notice<Service>>> FindAllAsync()
    {
        var notice = await context.Notices.Where(n=>n.IsDeleted==false).ToListAsync<Notice<Service>>();
        return notice;
    }
    public Task<Notice<Service>> FindAsync(INotice document)
    {
        throw new NotImplementedException();
    }
}


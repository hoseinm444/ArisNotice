
using ArisNotices.Domain.AggregatesModel.Notice;
using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;
using System.Text;
//using Sms.Api.Protos;
using SmsGrpcService.Protos;
//using SmsSender.Protos;
//using SimpleEmailApp.Protos;

namespace ArisNotices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        private readonly INoticeRepository repository;
        public NoticeController(INoticeRepository repository)
        {
            this.repository = repository;

        }


        [HttpPost("create/")]
        public async Task<IActionResult> Create([FromForm] NoticeDto noticeDto)
        {
            if (noticeDto is not null)
            {

                Notice<Service>? newNotice = new Notice<Service>(noticeDto);
                ///gRpc Send Info for EmailServer 

                //GrpcSendEmail(newNotice);
                GrpcSendSms(newNotice);



                Notice<Service>? NoticeDto = await repository.AddAsync(newNotice);
                if (NoticeDto is not null)
                    return Ok(NoticeDto);
                else return BadRequest();

                
            }
            else
                return BadRequest();
        }
        [HttpGet("Find")]
        public async Task<IEnumerable<Notice<Service>>> GetAllService()
        {
            var notice = await repository.FindAllAsync();
            return notice;

        }

        [HttpGet("Find/FindByNoticeHeader")]
        public async Task<IActionResult> FindByNoticeHeader(string header,
            CancellationToken cancellationToken = default)
        {
            var notice = await repository.FindByNoticeHeaderAsync(header, cancellationToken);
            if (notice is not null)
                return Ok(notice);
            else
                return NotFound();
        }

        [HttpPut("update/")]
        public async Task<IActionResult> Update(Guid id,[FromForm] NoticeDto notice)
        {
            if (notice is not null)
            {
                var NoticeDto = await repository.UpdateAsync(notice);
                if (NoticeDto is not null)
                    return Ok(NoticeDto);
                else
                    return NotFound(notice.Id);

                var json = NoticeDto.JsonNoticeSerializer();
                //var integrationEventData = JsonSerializer.Serialize(new
                //{
                //    id = NoticeDto.ID,
                //    newname = NoticeDto.Name
                //     .
                //     .
                //});//you can use this way to serialize something this sentence is tutorial

            }
            else
                return BadRequest();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await repository.DeleteByIdAsync(id))
                return Ok(id);
            else
                return NotFound(id);
        }

        //private void GrpcSendEmail(Notice<Service> notice)
        // {
        //     using var grpcChannel = GrpcChannel.ForAddress("https://localhost:7156/");
        //     var client = new EmailService.EmailServiceClient(grpcChannel);


        //     EmailAndTimeSchedulle Request = new EmailAndTimeSchedulle
        //     {
        //         Title = notice.Title,
        //         Description = notice.Description,
        //         Recipient = notice.Recipient,
        //         IsSend = notice.SendResult.ToString(),
        //        DeliverySchedule=notice.DeliverySchedule
        //     };

        //     var response = client.EmailInfo(Request).ToString();
        //   notice.ResultOfNotice(response);

        // }

        private void GrpcSendSms(Notice<Service> notice)
        {
            using var grpcChannel = GrpcChannel.ForAddress("https://localhost:7157/");
            var client = new SmsService.SmsServiceClient(grpcChannel);


            SmsTextAndSchedule Request = new SmsTextAndSchedule
            {
                SmsTitle = notice.Title,
                SmsDescription = notice.Description,
                SmsRecipient = notice.Recipient,
                SmsDeliverySchedule = notice.DeliverySchedule
            };

            var response = client.SmsInfo(Request).ToString();
            //var result = client.SmsResponseService(new Empty()).ToString();
            notice.ResultOfNotice(response);

        }
    }
}

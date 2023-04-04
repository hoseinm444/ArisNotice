
//using Grpc.Core;
//using SimpleEmailApp.Protos;

//namespace NoticeGrpcServer.Services;
//public class NoticeSenderService : EmailService.EmailServiceClient

//{
//    private readonly ILogger<NoticeSenderService> _logger;
//    public NoticeSenderService(ILogger<NoticeSenderService> logger)
//    {
//        _logger = logger;
//    }

//    //        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
//    //        {
//    //            return Task.FromResult(new HelloReply
//    //            {
//    //                Message = "Hello " + request.Name
//    //            });
//    //        }
//    //public override Task<EmailDTOResponse> SendNotice(EmailRequest request, ServerCallContext context)
//    //{
//    //    // string result = request.SendResult.ToString();
//    //    return Task.FromResult(new EmailDTOResponse
//    //    {

//    //    });

//    //}
//    //public override Task<PeriodicWorkResponse> PeriodicWork(EmailPeriodicTime request, ServerCallContext context)
//    //{
//    //    string result = request.ToString();
//    //    //    return Task.FromResult(new EmailDTOResponse
//    //    //    {

//    //    //    });
//    //}
//}
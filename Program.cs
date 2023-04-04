
using ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;
using ArisNotices.Domain.AggregatesModel.NoticeService;
using ArisNotices.Infra.Data.Sql;
using ArisNotices.Infra.Data.Sql.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddScoped<IServiceRepository, ServiceRepository>(con => new ServiceRepository(ContextFactory.GetSqlContext()));
builder.Services.AddScoped<INoticeRepository, NoticeRepository>(con => new NoticeRepository(ContextFactory.GetSqlContext()));
builder.Services.AddScoped<IApplicationRegisterRepository, ApplicationRegisterRepository>(con => new ApplicationRegisterRepository(ContextFactory.GetSqlContext()));
//builder.Services.AddGrpc();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.
//app.MapGrpcService<NoticeSenderService>();
//app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

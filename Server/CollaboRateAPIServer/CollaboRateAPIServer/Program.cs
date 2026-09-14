using Microsoft.EntityFrameworkCore;
using CollaboRateAPIServer.Data;
using CollaboRateAPIServer.Hubs;
using CollaboRateAPIServer.Interceptors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSignalR();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the interceptor
builder.Services.AddScoped<NotificationInterceptor>();
builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var interceptor = serviceProvider.GetRequiredService<NotificationInterceptor>();
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .AddInterceptors(interceptor);
});

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

// Map SignalR hubs route
app.MapHub<ChatHub>("/chathub");
app.MapHub<NotificationHub>("/notificationHub");

app.Run();

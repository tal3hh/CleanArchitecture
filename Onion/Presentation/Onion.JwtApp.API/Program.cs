using Onion.JwtApp.Application;
using Onion.JwtApp.Persistance;

var builder = WebApplication.CreateBuilder(args);


#region Service Registration

builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);

#endregion


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

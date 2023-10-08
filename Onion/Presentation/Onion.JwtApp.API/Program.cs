using Onion.JwtApp.Application;
using Onion.JwtApp.Persistance;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();


#region Service Registration

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddPersistanceServices(builder.Configuration);

#endregion



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

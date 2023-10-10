using Onion.JwtApp.Application.Services.Interface;
using Onion.JwtApp.Application.Services;
using FluentValidation;
using Onion.JwtApp.Application.Dtos.Category;
using Onion.JwtApp.Application.FluentValidations.Category;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFoodService, FoodService>();

builder.Services.AddScoped<IValidator<CategoryCreateDto>, CreateCategoryDtoValidation>();
builder.Services.AddScoped<IValidator<CategoryDto>, UpdateCategoryDtoValidation>();

builder.Services.AddFluentValidationAutoValidation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Default2",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
